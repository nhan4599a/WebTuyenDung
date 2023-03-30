using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;

namespace WebTuyenDung.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly RecruimentDbContext dbContext;

        public AuthenticationController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("/authentication/sign-in")]
        public IActionResult SignIn(string? returnUrl = "/")
        {
            TempData[AuthenticationConstants.RETURN_URL] = returnUrl;
            return View();
        }

        [HttpPost("/authentication/sign-in")]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> SignIn([FromBody][FromForm] SignInRequest signInRequest)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(e => e.Username == signInRequest.Username);

            if (user == null || user.PasswordHashed != signInRequest.Password.Sha256())
            {
                return BadRequest("Sai tên đăng nhập hoặc mật khẩu");
            }

            await HttpContext.SignInAsync(user);

            TempData[AuthorizationConstants.IS_FIRED_BY_AUTHENTICATION_ENDPOINT] = true;

            return Redirect((string)(TempData[AuthenticationConstants.RETURN_URL] ?? "/"));
        }

        [HttpPost("/authentication/sign-up")]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            var isUserExisted = await dbContext.Users.AnyAsync(e => e.Username == signUpRequest.Username);

            if (isUserExisted)
            {
                return BadRequest("Tên đăng nhập đã được sử dụng");
            }

            dbContext.Users.Add(new User
            {
                Username = signUpRequest.Username,
                PasswordHashed = signUpRequest.Password.Sha256(),
                Name = signUpRequest.Name,
                Role = UserRole.Candidate
            });

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("/authentication/sign-out")]
        public async new Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
