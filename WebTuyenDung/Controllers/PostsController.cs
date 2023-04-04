using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.Controllers
{
    public class PostsController : Controller
    {
        private readonly RecruimentDbContext dbContext;
        private readonly CreatePostService createPostService;

        public PostsController(RecruimentDbContext dbContext, CreatePostService createPostService)
        {
            this.dbContext = dbContext;
            this.createPostService = createPostService;
        }

        [Authorize(Policy = AuthorizationConstants.AUTHORIZED_PERSON_POLICY)]
        [HttpPost]
        public Task<IActionResult> Create(CreatePostViewModel createPostViewModel)
        {
            return createPostService.CreatePostAsync(this, createPostViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(e => e.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [Authorize(Policy = AuthorizationConstants.AUTHORIZED_PERSON_POLICY)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCount = await dbContext
                                        .Posts
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new Models.Post { IsDeleted = true });

            return deletedCount == 1 ? Ok() : BadRequest();
        }
    }
}
