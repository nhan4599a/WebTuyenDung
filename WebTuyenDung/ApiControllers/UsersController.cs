using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Data;

namespace WebTuyenDung.ApiControllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPatch("approve/{employerId}")]
        public async Task<IActionResult> ApproveEmployer(int employerId)
        {
            await DbContext.Employers.SingleMergeAsync(new Models.Employer
            {
                Id = employerId,
                IsApproved = true
            });

            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var deletedCount = await DbContext.Users.DeleteByKeyAsync(userId);

            return deletedCount != 1 ? BadRequest() : Ok();
        }
    }
}
