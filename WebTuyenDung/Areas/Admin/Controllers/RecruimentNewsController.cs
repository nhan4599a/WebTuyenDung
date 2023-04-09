using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Admin;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    [ControllerName("recruiment-news")]
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

            return query.PaginateAsync<RecruimentNews, RecruimentNewsViewModel>(searchRequest);
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
