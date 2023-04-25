using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Controllers
{
    [ControllerName("saved-jobs")]
    [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
    public class SavedJobsController : BaseController
    {
        public SavedJobsController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Index()
        {
            var candidateId = User.GetUserId();

            var savedJobs = DbContext.SavedRecruimentNews.Where(e => e.CandidateId == candidateId).AsAsyncEnumerable();

            return View(savedJobs);
        }
    }
}
