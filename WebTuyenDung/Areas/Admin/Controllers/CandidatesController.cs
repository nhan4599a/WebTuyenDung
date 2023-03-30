using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.Enums;
using WebTuyenDung.ViewModels.Admin;

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
        public Task<PaginationResult<CandidateViewModel>> Search(SearchRequest searchRequest)
        {
            IQueryable<Candidate> query = dbContext.Candidates.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync(
                            searchRequest.PageIndex,
                            searchRequest.PageSize,
                            e => new CandidateViewModel
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Gender = e.Gender.GetRepresentation(),
                                Address = e.Address,
                                BirthDay = e.BirthDay.ToString(),
                                PhoneNumber = e.PhoneNumber
                            });
        }
    }
}
