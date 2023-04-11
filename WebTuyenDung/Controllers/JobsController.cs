using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Page;
using WebTuyenDung.ViewModels.User;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Controllers
{
    public class JobsController : BaseController
    {
        private readonly FileService _fileService;

        public JobsController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(SearchJobRequest request)
        {
            IQueryable<RecruimentNews> jobsQuery = DbContext.RecruimentNews;

            if (request.JobType != null)
            {
                jobsQuery = jobsQuery.Where(e => e.JobType == request.JobType);
            }

            var hotJobsQuery = jobsQuery.QueryTopItems<TopJobsViewModel>(5)
                                        .Select(e => new TopJobsViewModel(e)
                                        {
                                            Employer = new BaseEmployerViewModel(e.Employer)
                                            {
                                                Avatar = _fileService.GetStaticFileUrlForFile(e.Employer.Avatar, FilePath.Avatar)
                                            }
                                        })
                                        .Future();

            var jobs = await jobsQuery.PaginateAsync<RecruimentNews, DetailRecruimentNewsViewModel>(request)
                                      .Select(e => new DetailRecruimentNewsViewModel(e)
                                      {
                                          Employer = new BaseEmployerViewModel(e.Employer)
                                          {
                                              Avatar = _fileService.GetStaticFileUrlForFile(e.Employer.Avatar, FilePath.Avatar)
                                          }
                                      });

            return View(new JobsPageViewModel
            {
                TopRecruimentNews = await hotJobsQuery.ToListAsync(),
                SearchResult = jobs
            });
        }
    }
}
