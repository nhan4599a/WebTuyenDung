using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;

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
            try
            {
                var deletedCount = await DbContext.Users.DeleteByKeyAsync(userId);
                return deletedCount != 1 ? BadRequest() : Ok();
            }
            catch (Exception)
            {
                return BadRequest("User này đã có thông tin, không thể xóa");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] AssignRoleRequest request)
        {
            await DbContext.Users.Where(e => e.Id == id).UpdateFromQueryAsync(e => new User
            {
                Role = request.Role
            });

            return Ok();
        }
    }
}
