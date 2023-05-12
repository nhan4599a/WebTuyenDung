using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Controllers
{
    public class UserController : BaseController
    {
        public UserController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        [ActionName("info")]
        [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
        public async Task<IActionResult> ViewUserInfo()
        {
            var userId = User.GetUserId();

            var candidate = await DbContext.Candidates.FirstOrDefaultAsync(e => e.Id == userId);

            return View(candidate);
        }

        [ActionName("info")]
        [HttpPost]
        [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
        public async Task<IActionResult> UpdateUserInfo(Candidate candidate)
        {
            await DbContext.Candidates
                            .Where(e => e.Id == candidate.Id)
                            .UpdateFromQueryAsync(e => new Candidate
                            {
                                Name = candidate.Name,
                                PhoneNumber = candidate.PhoneNumber,
                                Gender = candidate.Gender,
                                BirthDay = candidate.BirthDay,
                                Address = candidate.Address
                            });

            TempData["popup"] = "Cập nhật thông tin thành công";

            return View(candidate);
        }

        [ActionName("change-password")]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName("change-password")]
        [Authorize]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            var userId = User.GetUserId();

            var actualPassword = await DbContext.Users.Where(e => e.Id == userId).Select(e => e.PasswordHashed).FirstAsync();

            if (changePasswordRequest.OldPassword.Sha256() != actualPassword)
            {
                ModelState.AddModelError("Password", "Password is not correct");
                return BadRequest(ModelState);
            }

            await DbContext
                    .Users
                    .Where(e => e.Id == userId)
                    .UpdateFromQueryAsync(e => new User
                    {
                        PasswordHashed = changePasswordRequest.NewPassword.Sha256()
                    });

            return View();
        }
    }
}
