using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Data;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly RecruimentDbContext dbContext;

        public HomeController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
