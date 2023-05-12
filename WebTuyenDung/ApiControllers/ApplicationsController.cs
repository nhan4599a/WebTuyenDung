using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Employer;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.ApiControllers
{
    public class ApplicationsController : BaseApiController
    {
        public ApplicationsController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        [Route("{employerId}")]
        public Task<IPaginationResult<JobApplicationViewModel>> GetJobApplications(
            int employerId, [FromQuery] SearchRequest searchRequest)
        {
            var query = DbContext.RecruimentNews
                                 .Where(e => e.EmployerId == employerId)
                                 .SelectMany(e => e.JobApplications)
                                 .OrderByDescending(e => e.CV.LikeCount)
                                 .AsNoTracking();

            var likedCVIdList = DbContext.LikedCVs
                                            .Where(e => e.EmployerId == employerId)
                                            .Select(e => e.CVId)
                                            .ToHashSet();

            return query.PaginateAsync<JobApplication, JobApplicationViewModel>(searchRequest)
                        .Select(e => new JobApplicationViewModel(e)
                        {
                            IsLiked = likedCVIdList.Contains(e.CVId)
                        });
        }

        [HttpPost]
        public async Task<IActionResult> Like([FromForm] LikeCvRequest request)
        {
            var cvId = await DbContext.JobApplications.Where(e => e.Id == request.Id).Select(e => e.CVId).FirstOrDefaultAsync();

            var userId = User.GetUserId();

            if (!request.IsLiked)
            {
                var isCreatedBeforeQuery = DbContext.LikedCVs.DeferredAny(e => e.CVId == cvId && e.EmployerId == userId).FutureValue();
                var cvItemQuery = DbContext.CVs.Where(e => e.Id == cvId).DeferredFirstOrDefault().FutureValue();

                var isCreatedBefore = await isCreatedBeforeQuery.ValueAsync();
                var cvItem = await cvItemQuery.ValueAsync();

                if (!isCreatedBefore)
                {
                    DbContext.LikedCVs.Add(new LikedCurriculumVitae
                    {
                        CVId = cvId,
                        EmployerId = userId
                    });

                    cvItem.LikeCount += 1;
                }

                await DbContext.SaveChangesAsync();
            }
            else
            {
                await DbContext.LikedCVs
                                .Where(e => e.CVId == cvId && e.EmployerId == userId)
                                .DeleteFromQueryAsync();

                await DbContext.CVs.Where(e => e.Id == cvId).UpdateFromQueryAsync(e => new CurriculumVitae
                {
                    LikeCount = e.LikeCount - 1
                });
            }

            return Ok();
        }
    }
}
