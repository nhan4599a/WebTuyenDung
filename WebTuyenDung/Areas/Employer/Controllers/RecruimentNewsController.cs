using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Employer;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class RecruimentNewsController : BaseEmployerController
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
                                Title = e.JobName,
                                NumberOfCandidates = e.NumberOfCandidates,
                                CreatedAt = e.CreatedAt.GetApplicationTimeRepresentation(),
                                Status = e.IsApproved ? "Đã duyệt" : "Chưa được duyệt"
                            });
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
