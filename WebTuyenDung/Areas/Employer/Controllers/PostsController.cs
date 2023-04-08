using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;

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

        public Task<PaginationResult<ViewModels.Admin.PostViewModel>> Search(SearchPostsRequest searchRequest)
        {
            IQueryable<Post> query = dbContext.Posts.AsNoTracking().Where(e => e.IsApproved == searchRequest.IsApproved);

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Title.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync(
                            searchRequest.PageIndex,
                            searchRequest.PageSize,
                            e => new ViewModels.Admin.PostViewModel
                            {
                                Id = e.Id,
                                Title = e.Title,
                                Author = e.Author.Name,
                                CreatedAt = e.CreatedAt.GetApplicationTimeRepresentation(),
                                Image = fileService.GetStaticFileUrlForFile(e.Image, FilePath.Post),
                                View = e.View,
                                Status = e.IsApproved ? "Đã duyệt" : "Chưa được duyệt"
                            });
        }
    }
}
