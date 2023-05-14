using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Admin;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class CandidatesController : BaseAdminController
    {
        private readonly RecruimentDbContext _dbContext;

        public CandidatesController(RecruimentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<IPaginationResult<CandidateViewModel>> Search(SearchRequest searchRequest)
        {
            IQueryable<Candidate> query = _dbContext.Candidates.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync<Candidate, CandidateViewModel>(searchRequest);
        }

        [HttpGet("/admin/candidates/{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(e => e.Id == id);

            return View(candidate);
        }

    }
}
