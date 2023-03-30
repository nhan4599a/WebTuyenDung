using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.Controllers
{
    public class PostsController : Controller
    {
        private readonly CreatePostService createPostService;

        public PostsController(CreatePostService createPostService)
        {
            this.createPostService = createPostService;
        }

        [Authorize(Policy = AuthorizationConstants.AUTHORIZED_PERSON_POLICY)]
        [HttpPost]
        public Task<IActionResult> Create(CreatePostViewModel createPostViewModel)
        {
            return createPostService.CreatePostAsync(this, createPostViewModel);
        }
    }
}
