using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.HomePage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebTuyenDung.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecruimentDbContext dbContext;

        public HomeController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var topRecruimentNews = GetTopRecruimentNews();
            var topPosts = GetTopPosts();

            var model = new HomePageViewModel
            {
                TopRecruimentNews = topRecruimentNews,
                TopPosts = topPosts
            };

            return View(model);
        }

        [NonAction]
        private List<HomePageRecruimentNewsViewModel> GetTopRecruimentNews()
        {
            return dbContext.RecruimentNews
                            .OrderByDescending(e => e.CreatedAt)
                            .Take(9)
                            .Select(e =>  new HomePageRecruimentNewsViewModel
                            {
                                Id = e.Id,
                                JobTitle = e.JobName,
                                JobType = e.JobType.GetRepresentation(),
                                Salary = e.Salary,
                                Employer = new EmployerViewModel
                                {
                                    Id = e.Employer.Id,
                                    Name = e.Employer.Name,
                                    Site = e.Employer.Address,
                                    AvatarUrl = e.Employer.Avatar!
                                }
                            })
                            .ToList();
        }

        [NonAction]
        private List<PostViewModel> GetTopPosts()
        {
            return dbContext.Posts
                            .Where(e => e.IsApproved)
                            .OrderByDescending(e => e.CreatedAt)
                            .Take(3)
                            .Select(e => new PostViewModel
                            {
                                Id = e.Id,
                                Image = e.Image,
                                PostedBy = e.Author.Name
                            })
                            .ToList();
        }
    }
}
