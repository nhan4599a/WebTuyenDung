using Microsoft.AspNetCore.Mvc;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class EmployersController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
