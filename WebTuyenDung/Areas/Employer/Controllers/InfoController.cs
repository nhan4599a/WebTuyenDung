using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class InfoController : BaseEmployerController
    {
        private readonly RecruimentDbContext _dbContext;

        public InfoController(RecruimentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();
            var employerInfo = await _dbContext.Employers.FirstOrDefaultAsync(e => e.Id == userId);
            return View(employerInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Models.Employer employer)
        {
            await _dbContext.Employers.Where(e => e.Id == employer.Id)
                            .UpdateFromQueryAsync(e => new Models.Employer
                            {
                                Name = employer.Name,
                                PhoneNumber = employer.PhoneNumber,
                                Size = employer.Size,
                                Description = employer.Description,
                                Address = employer.Address,
                                Website = employer.Website
                            });

            TempData["popup"] = "Cập nhật thông tin thành công";

            return View(employer);
        }
    }
}
