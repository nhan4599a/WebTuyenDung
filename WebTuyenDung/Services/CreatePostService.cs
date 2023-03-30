using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.Services
{
    public class CreatePostService
    {
        private readonly RecruimentDbContext dbContext;
        private readonly ImageService imageService;

        public CreatePostService(RecruimentDbContext dbContext, ImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }

        public async Task<IActionResult> CreatePostAsync(Controller controller, CreatePostViewModel createPostViewModel)
        {
            var areaName = controller.TempData[ViewConstants.VIEW_AREA]!.ToString()!;

            if (!controller.ModelState.IsValid)
            {
                return controller.View();
            }

            var post = new Post
            {
                Title = createPostViewModel.Title,
                Image = await imageService.SaveAsync(createPostViewModel.Image, ImagePath.Post),
                Content = createPostViewModel.Content,
                CreatedBy = controller.User.GetUserId(),
                IsApproved = areaName == "admin"
            };

            dbContext.Posts.Add(post);

            await dbContext.SaveChangesAsync();

            return controller.Redirect($"/{areaName}/posts");
        }
    }
}
