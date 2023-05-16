using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;

namespace WebTuyenDung.Controllers
{
    public class BaseController : Controller
    {
        protected RecruimentDbContext DbContext { get; }

        protected BaseController(RecruimentDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isSharedAction = context.ActionDescriptor.EndpointMetadata.OfType<SharedActionAttribute>().Any();

            if (User.Identity!.IsAuthenticated && !User.IsInRole(AuthorizationConstants.CANDIDATE_ROLE) && !isSharedAction)
            {
                await HttpContext.SignOutAsync();
                HttpContext.Response.Redirect(HttpContext.Request.Path);
            }

            var shouldAutoReturnBadRequest = context
                                                .ActionDescriptor
                                                .EndpointMetadata
                                                .OfType<AutoShortCircuitValidationFailedRequestAttribute>()
                                                .Any();

            if (shouldAutoReturnBadRequest && !ModelState.IsValid)
            {
                context.Result = BadRequest(ModelState);
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
