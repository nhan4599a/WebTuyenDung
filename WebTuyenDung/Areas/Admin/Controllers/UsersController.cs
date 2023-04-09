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
    public class UsersController : BaseAdminController
    {
        private readonly RecruimentDbContext dbContext;

        public UsersController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<PaginationResult<UserViewModel>> Search(SearchRequest searchRequest)
        {
            IQueryable<User> query = dbContext.Users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync<User, UserViewModel>(searchRequest);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
