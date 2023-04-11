using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Services;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class PostsController : BaseEmployerController
    {
        private readonly RecruimentDbContext dbContext;
        private readonly FileService fileService;

        public PostsController(RecruimentDbContext dbContext, FileService fileService)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            TempData[ViewConstants.VIEW_AREA] = ViewConstants.EMPLOYER_AREA;
            return View("CreatePost");
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData[ViewConstants.VIEW_AREA] = ViewConstants.EMPLOYER_AREA;

            var post = await dbContext.Posts.FirstOrDefaultAsync(e => e.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View("EditPost", post);
        }
    }
}
