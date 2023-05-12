using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            _dbContext.Entry(employer).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return View(employer);
        }
    }
}
