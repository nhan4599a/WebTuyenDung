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
        public Task<IPaginationResult<AdminViewModels.EmployerViewModel>> Search(SearchRequest searchRequest)
        {
            IQueryable<Models.Employer> query = dbContext.Employers.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync<Models.Employer, EmployerViewModel>(searchRequest);
        }
    }
}
