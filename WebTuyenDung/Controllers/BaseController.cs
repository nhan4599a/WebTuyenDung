using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;

namespace WebTuyenDung.Controllers
{
    public class BaseController : Controller
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var shouldAutoReturnBadRequest = context
                                                .ActionDescriptor
                                                .EndpointMetadata
                                                .OfType<AutoShortCircuitValidationFailedRequestAttribute>()
                                                .Any();

            if (shouldAutoReturnBadRequest && !ModelState.IsValid)
            {
                context.Result = BadRequest(ModelState);
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
