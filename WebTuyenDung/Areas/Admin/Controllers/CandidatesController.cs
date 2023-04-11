using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Enums;
using WebTuyenDung.ViewModels.Admin;
using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class CandidatesController : BaseAdminController
    {
        private readonly RecruimentDbContext dbContext;

        public CandidatesController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<IPaginationResult<CandidateViewModel>> Search(SearchRequest searchRequest)
        {
            IQueryable<Candidate> query = dbContext.Candidates.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync<Candidate, CandidateViewModel>(searchRequest);
        }
    }
}
