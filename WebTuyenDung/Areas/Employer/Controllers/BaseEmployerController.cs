using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    [Area("employer")]
    [Authorize(Policy = AuthorizationConstants.EMPLOYER_ONLY_POLICY)]
    public class BaseEmployerController : Controller
    {
    }
}
