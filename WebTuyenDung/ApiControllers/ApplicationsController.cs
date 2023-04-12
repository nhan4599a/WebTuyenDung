using Mapster;
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
                                 .AsNoTracking();

            return query.PaginateAsync<JobApplication, JobApplicationViewModel>(searchRequest);
        }
    }
}
