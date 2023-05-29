﻿using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels.Api;

namespace WebTuyenDung.Controllers
{
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        [ActionName("sign-in")]
        public IActionResult SignIn(string? returnUrl = "/")
        {
            TempData[AuthenticationConstants.RETURN_URL] = returnUrl;
            return View();
        }

        [ActionName("sign-in")]
        [HttpPost]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> SignIn([FromBody][FromForm] SignInRequest signInRequest)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(e => e.Username == signInRequest.Username);

            if (user == null || user.PasswordHashed != signInRequest.Password.Sha256())
            {
                return BadRequest("Sai tên đăng nhập hoặc mật khẩu");
            }

            var employer = user as Employer;

            if (employer != null && !employer.IsApproved)
            {
                return BadRequest("Nhà tuyển dụng chưa được xác nhận bởi admin");
            }
            if (employer != null && employer.LockedOutAt != null && employer.LockedOutAt < DateTimeOffset.Now)
            {
                return BadRequest("Bạn chưa thanh toán tiền cho admin");
            }

            await HttpContext.SignInAsync(user);

            TempData[AuthorizationConstants.IS_FIRED_BY_AUTHENTICATION_ENDPOINT] = true;

            return Redirect((string)(TempData[AuthenticationConstants.RETURN_URL] ?? "/"));
        }

        [ActionName("sign-up")]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [ActionName("sign-up")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] CandidateSignUpRequest signUpRequest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isUserExisted = await ValidateUsername(signUpRequest.Username);

            if (isUserExisted)
            {
                return BadRequest("Tên đăng nhập đã được sử dụng");
            }

            var candidate = signUpRequest.Adapt<Candidate>();
            candidate.Role = UserRole.Candidate;

            DbContext.Candidates.Add(candidate);

            await DbContext.SaveChangesAsync();

            return Redirect("/authentication/sign-in");
        }

        [ActionName("sign-up-employer")]
        [HttpGet]
        public IActionResult SignUpEmployer()
        {
            var model = DbContext
                            .Locales
                            .Where(e => e.Parent == null)
                            .ProjectToType<LocaleViewModel>()
                            .AsNoTracking()
                            .AsAsyncEnumerable();

            return View(model);
        }

        [ActionName("sign-up-employer")]
        [HttpPost]
        public async Task<IActionResult> SignUpEmployer([FromForm] SignUpEmployerRequest signUpRequest)
        {
            if (!ModelState.IsValid)
            {
                var model = DbContext
                            .Locales
                            .Where(e => e.Parent == null)
                            .ProjectToType<LocaleViewModel>()
                            .AsNoTracking()
                            .AsAsyncEnumerable();

                return View(model);
            }

            var isUserExisted = await ValidateUsername(signUpRequest.Username);

            if (isUserExisted)
            {
                return BadRequest("Tên đăng nhập đã được sử dụng");
            }

            var transaction = await DbContext.Database.BeginTransactionAsync();

            var employer = signUpRequest.Adapt<Employer>();
            employer.IsApproved = false;
            employer.Role = UserRole.Employer;

            DbContext.Employers.Add(employer);

            await DbContext.SaveChangesAsync();

            DbContext.Debt.Add(new EmployerDebt
            {
                EmployerId = employer.Id
            });

            await transaction.CommitAsync();

            return Redirect("/authentication/sign-in?ReturnUrl=%2FEmployer");
        }

        [ActionName("validate")]
        [HttpGet]
        public Task<bool> ValidateUsername(string username)
        {
            return DbContext.Users.AnyAsync(e => e.Username == username);
        }

        [ActionName("sign-out")]
        [HttpPost]
        public async new Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
