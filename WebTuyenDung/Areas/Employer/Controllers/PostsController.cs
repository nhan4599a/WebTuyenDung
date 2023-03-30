using Microsoft.AspNetCore.Mvc;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class PostsController : BaseEmployerController
    {
        public IActionResult Create()
        {
            TempData[ViewConstants.VIEW_AREA] = ViewConstants.EMPLOYER_AREA;
            return View();
        }
    }
}
