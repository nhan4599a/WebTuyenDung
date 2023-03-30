using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    [Area(ViewConstants.ADMIN_AREA)]
    [Authorize(Roles = AuthorizationConstants.ADMIN_ROLE)]
    public class BaseAdminController : Controller
    {
    }
}
