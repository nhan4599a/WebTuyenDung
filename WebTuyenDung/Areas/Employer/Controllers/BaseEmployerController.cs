using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    [Area("employer")]
    [Authorize(Roles = AuthorizationConstants.EMPLOYER_ROLE)]
    public class BaseEmployerController : Controller
    {
    }
}
