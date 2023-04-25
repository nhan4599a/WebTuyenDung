using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class PostsController : BaseAdminController
    {
        private readonly RecruimentDbContext dbContext;

        public PostsController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            TempData[ViewConstants.VIEW_AREA] = ViewConstants.ADMIN_AREA;
            return View("CreatePost");
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData[ViewConstants.VIEW_AREA] = ViewConstants.ADMIN_AREA;

            var post = await dbContext.Posts.FirstOrDefaultAsync(e => e.Id == id);

            if (post == null)
            {
                return NotFound();
            }    

            return View("EditPost", post);
        }
    }
}
