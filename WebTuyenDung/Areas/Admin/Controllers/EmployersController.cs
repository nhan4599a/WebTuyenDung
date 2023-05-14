using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebTuyenDung.Data;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class EmployersController : BaseAdminController
    {
        private readonly RecruimentDbContext _dbContext;

        public EmployersController(RecruimentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/employers/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var employer = await _dbContext.Employers.FirstOrDefaultAsync(e => e.Id == id);

            return View("Detail", employer);
        }
    }
}
