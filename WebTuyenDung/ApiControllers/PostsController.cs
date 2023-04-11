using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.Abstraction;
using ManagementViewModels = WebTuyenDung.ViewModels.Management;

namespace WebTuyenDung.ApiControllers
{
    public class PostsController : BaseApiController
    {
        private readonly FileService _fileService;

        public PostsController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }
        
        [HttpGet("management/{employerId?}")]
        public async Task<IPaginationResult<ManagementViewModels.MinimalPostViewModel>> GetPostsManagement(
            int? employerId, [FromQuery] SearchPostsRequest searchRequest)
        {
            var query = DbContext.Posts.Where(e => e.IsApproved == searchRequest.IsApproved).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => EF.Functions.Like(e.Title, $"%{searchRequest.Keyword}%"));
            }

            if (employerId.HasValue)
            {
                return await query.Where(e => e.CreatedBy == employerId)
                                  .PaginateAsync<Post, ManagementViewModels.MinimalPostViewModel>(searchRequest)
                                  .Select(e => new ManagementViewModels.MinimalPostViewModel(e)
                                  {
                                      Image = _fileService.GetStaticFileUrlForFile(e.Image, FilePath.Post)
                                  });
            }
            else
            {
                var temp = await query.PaginateAsync<Post, ManagementViewModels.PostViewModel>(searchRequest)
                                  .Select(e => new ManagementViewModels.PostViewModel(e)
                                  {
                                      Image = _fileService.GetStaticFileUrlForFile(e.Image, FilePath.Post)
                                  });
                return temp;
            }
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApprovePost(int id)
        {
            var approvedCount = await DbContext
                                        .Posts
                                        .Where(e => e.Id == id && !e.IsApproved)
                                        .UpdateFromQueryAsync(e => new Post
                                        {
                                            IsApproved = true
                                        });

            return approvedCount == 1 ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var deletedCount = await DbContext
                                        .Posts
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new Post
                                        {
                                            IsDeleted = true
                                        });

            return deletedCount == 1 ? Ok() : BadRequest();
        }

    }
}
