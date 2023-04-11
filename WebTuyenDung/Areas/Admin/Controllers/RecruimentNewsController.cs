using Microsoft.AspNetCore.Mvc;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    [ControllerName("recruiment-news")]
    public class RecruimentNewsController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
