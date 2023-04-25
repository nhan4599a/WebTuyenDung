using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            var isUserExisted = await DbContext.Users.AnyAsync(e => e.Username == signUpRequest.Username);

            if (isUserExisted)
            {
                return BadRequest("Tên đăng nhập đã được sử dụng");
            }

            var user = signUpRequest.Adapt<User>();
            user.Role = UserRole.Candidate;

            DbContext.Users.Add(user);

            await DbContext.SaveChangesAsync();

            return Ok();
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
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> SignUpEmployer([FromBody] SignUpEmployerRequest signUpRequest)
        {
            var isUserExisted = await DbContext.Users.AnyAsync(e => e.Username == signUpRequest.Username);

            if (isUserExisted)
            {
                return BadRequest("Tên đăng nhập đã được sử dụng");
            }

            var employer = signUpRequest.Adapt<Employer>();
            employer.IsApproved = false;
            employer.Role = UserRole.Employer;

            DbContext.Employers.Add(employer);

            await DbContext.SaveChangesAsync();

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
