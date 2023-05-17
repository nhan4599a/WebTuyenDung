using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;

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

            if (User.Identity!.IsAuthenticated && User.IsInRole(AuthorizationConstants.CANDIDATE_ROLE))
            {
                var userId = User.GetUserId();

                var numberOfCandidatesQuery = await DbContext.JobApplications
                                                            .Where(e => e.CandidateId == userId)
                                                            .GroupBy(e => e.Status)
                                                            .Select(e => new { e.Key, Count = e.Count() })
                                                            .ToListAsync();

                var numeberOfCandidatesCounts = numberOfCandidatesQuery.ToDictionary(e => e.Key, e => e.Count);

                numeberOfCandidatesCounts.TryGetValue(JobApplicationStatus.Potential, out var potentialCandidates);
                numeberOfCandidatesCounts.TryGetValue(JobApplicationStatus.Scheduled, out var scheduledCandidates);
                numeberOfCandidatesCounts.TryGetValue(JobApplicationStatus.Passed, out var passedCandidates);
                numeberOfCandidatesCounts.TryGetValue(JobApplicationStatus.Rejected, out var failedCandidates);

                ViewData["potential-candidates"] = potentialCandidates;
                ViewData["scheduled-candidates"] = scheduledCandidates;
                ViewData["passed-candidates"] = passedCandidates;
                ViewData["failed-candidates"] = failedCandidates;
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
