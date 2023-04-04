using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using AdminViewModels = WebTuyenDung.ViewModels.Admin;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class EmployersController : BaseAdminController
    {
        private readonly RecruimentDbContext dbContext;

        public EmployersController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<PaginationResult<AdminViewModels.EmployerViewModel>> Search(SearchRequest searchRequest)
        {
            IQueryable<Models.Employer> query = dbContext.Employers.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync(
                            searchRequest.PageIndex,
                            searchRequest.PageSize,
                            e => new AdminViewModels.EmployerViewModel
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Size = e.Size,
                                Address = e.Address,
                                PhoneNumber = e.PhoneNumber,
                                Website = e.Website
                            });
        }
    }
}
