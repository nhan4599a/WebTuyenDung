using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Page;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Controllers
{
    public class HomeController : BaseController
    {
        private readonly FileService _fileService;

        public HomeController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var homePageViewModel = await GetHomePageDataAsync();

            return View(homePageViewModel);
        }

        private async Task<HomePageViewModel> GetHomePageDataAsync()
        {
            var recruimentNewsQuery = DbContext.RecruimentNews
                                                .QueryTopItems<ViewModels.User.StandardRecruimentNewsViewModel>(9)
                                                .Select(e => new ViewModels.User.StandardRecruimentNewsViewModel(e)
                                                {
                                                    Employer = new BaseEmployerViewModel(e.Employer)
                                                    {
                                                        Avatar = _fileService.GetStaticFileUrlForFile(e.Employer.Avatar, FilePath.Avatar)!
                                                    }
                                                }).Future();

            var postsQuery = DbContext.Posts.QueryTopItems(3, _fileService).Future();

            return new HomePageViewModel
            {
                TopRecruimentNews = await recruimentNewsQuery.ToListAsync(),
                TopPosts = await postsQuery.ToListAsync()
            };
        }
    }
}
