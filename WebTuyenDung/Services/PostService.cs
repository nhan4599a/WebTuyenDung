using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.Services
{
    public class PostService
    {
        private readonly RecruimentDbContext _dbContext;
        private readonly FileService _imageService;

        public PostService(RecruimentDbContext dbContext, FileService imageService)
        {
            this._dbContext = dbContext;
            this._imageService = imageService;
        }

        public async Task<IActionResult> CreatePostAsync(Controller controller, CreatePostViewModel createPostViewModel)
        {
            var areaName = controller.TempData[ViewConstants.VIEW_AREA]!.ToString()!;

            if (!controller.ModelState.IsValid)
            {
                var keyHasError = controller.ModelState.Where(e => (e.Value?.Errors.Count ?? 0) >= 1).Select(e => e.Key).ToHashSet();
                controller.TempData["error"] = JsonSerializer.Serialize(keyHasError);
                return controller.Redirect($"/{areaName}/posts/create");
            }

            var post = new Post
            {
                Title = createPostViewModel.Title,
                Image = await _imageService.SaveAsync(createPostViewModel.Image, FilePath.Post),
                Content = createPostViewModel.Content,
                CreatedBy = controller.User.GetUserId(),
                IsApproved = areaName == "admin"
            };

            _dbContext.Posts.Add(post);

            await _dbContext.SaveChangesAsync();

            return controller.Redirect($"/{areaName}/posts");
        }

        public async Task<IActionResult> UpdatePostAsync(Controller controller, UpdatePostViewModel updatePostViewModel)
        {
            var areaName = controller.TempData[ViewConstants.VIEW_AREA]!.ToString()!;

            if (!controller.ModelState.IsValid)
            {
                var keyHasError = controller.ModelState.Where(e => (e.Value?.Errors.Count ?? 0) >= 1).Select(e => e.Key).ToHashSet();
                controller.TempData["error"] = JsonSerializer.Serialize(keyHasError);
                return controller.Redirect($"/{areaName}/posts/edit/{updatePostViewModel.Id}");
            }

            if (updatePostViewModel.Image != null)
            {
                await _imageService.ReplaceFileAsync(updatePostViewModel.OldImage, updatePostViewModel.Image, FilePath.Post);
            }

            await _dbContext
                        .Posts
                        .Where(e => e.Id == updatePostViewModel.Id)
                        .UpdateFromQueryAsync(e => new Post
                        {
                            Title = updatePostViewModel.Title,
                            Content = updatePostViewModel.Content
                        });

            return controller.Redirect($"/{areaName}/posts");
        }
    }
}
