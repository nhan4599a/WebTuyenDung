using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Admin;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    [Route("{area}/recruiment-news/{action=Index}/{id?}")]
    public class RecruimentNewsController : BaseAdminController
    {
        private readonly RecruimentDbContext dbContext;

        public RecruimentNewsController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<PaginationResult<RecruimentNewsViewModel>> Search(SearchRecruimentNewsRequest searchRequest)
        {
            IQueryable<RecruimentNews> query = dbContext.RecruimentNews.AsNoTracking().FilterRecruimentNewsByMode(searchRequest.Mode);

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.JobName.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync(
                            searchRequest.PageIndex,
                            searchRequest.PageSize,
                            e => new RecruimentNewsViewModel
                            {
                                Id = e.Id,
                                JobName = e.JobName,
                                NumberOfCandidates = e.NumberOfCandidates,
                                CreatedAt = e.CreatedAt.GetApplicationTimeRepresentation(),
                                Deadline = e.Deadline.GetApplicationTimeRepresentation(),
                                EmployerName = e.Employer.Name,
                                View = e.View,
                                Status = e.IsApproved ? "Đã phê duyệt" : "Chờ phê duyệt"                                
                            });
        }

        [ActionName("Approve")]
        [HttpPut]
        public async Task<IActionResult> Approve(int id)
        {
            var approvedCount = await dbContext
                                        .RecruimentNews
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new RecruimentNews
                                        {
                                            IsApproved = true
                                        });

            return approvedCount == 1 ? Ok() : BadRequest();
        }
    }
}
