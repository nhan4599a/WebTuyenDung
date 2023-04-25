using Microsoft.AspNetCore.Mvc;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class CandidatesController : BaseEmployerController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
