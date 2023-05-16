using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Models;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.Controllers
{
    [Authorize(Policy = AuthorizationConstants.AUTHORIZED_PERSON_POLICY)]
    public class PostsController : BaseController
    {
        private readonly PostService _postService;

        private readonly FileService _fileService;

        public PostsController(RecruimentDbContext dbContext, PostService postService, FileService fileService) : base(dbContext)
        {
            _postService = postService;
            _fileService = fileService;
        }

        [HttpGet("posts/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            Expression<Func<Post, bool>> findPostByIdQuery = e => e.Id == id;

            var post = await DbContext.Posts.Where(findPostByIdQuery).ProjectToType<FullDetailPostViewModel>().FirstOrDefaultAsync();

            if (post == null)
            {
                return NotFound();
            }

            post.Image = _fileService.GetStaticFileUrlForFile(post.Image, FilePath.Post)!;

            await DbContext.Posts.Where(findPostByIdQuery).UpdateFromQueryAsync(e => new Post { View = e.View + 1 });

            return View(post);
        }

        [HttpPost]
        [SharedAction]
        public Task<IActionResult> Create(CreatePostViewModel createPostViewModel)
        {
            return _postService.CreatePostAsync(this, createPostViewModel);
        }

        [HttpPost]
        [SharedAction]
        public Task<IActionResult> Edit(UpdatePostViewModel editPostViewModel)
        {
            return _postService.UpdatePostAsync(this, editPostViewModel);
        }
    }
}
