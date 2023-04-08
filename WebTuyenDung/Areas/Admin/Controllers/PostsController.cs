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
using AdminViewModels = WebTuyenDung.ViewModels.Admin;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class PostsController : BaseAdminController
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

        [HttpGet]
        public Task<PaginationResult<AdminViewModels.PostViewModel>> Search(SearchPostsRequest searchRequest)
        {
            IQueryable<Post> query = dbContext.Posts.AsNoTracking().Where(e => e.IsApproved == searchRequest.IsApproved);

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Title.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync(
                            searchRequest.PageIndex,
                            searchRequest.PageSize,
                            e => new AdminViewModels.PostViewModel
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

        [ActionName("Approve")]
        [HttpPut]
        public async Task<IActionResult> ApprovePost(int id)
        {
            var approvedCount = await dbContext
                                        .Posts
                                        .Where(e => e.Id == id && !e.IsApproved)
                                        .UpdateFromQueryAsync(e => new Post
                                        {
                                            IsApproved = true
                                        });

            return approvedCount == 1 ? Ok() : BadRequest();
        }

        [HttpDelete("/admin/posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var deletedCount = await dbContext
                                        .Posts
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new Post
                                        {
                                            IsDeleted = true
                                        });

            return deletedCount == 1 ? Ok() : BadRequest();
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
