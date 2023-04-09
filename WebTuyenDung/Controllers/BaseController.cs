using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
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
