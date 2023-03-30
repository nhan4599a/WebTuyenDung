using Microsoft.AspNetCore.Mvc;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class HomeController : BaseEmployerController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
