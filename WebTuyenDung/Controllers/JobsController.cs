using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Candidate;
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

            var hotJobsQuery = jobsQuery.QueryTopItems<RecruimentNewsViewModel>(5)
                                        .Select(e => new RecruimentNewsViewModel(e)
                                        {
                                            Employer = new MinimalEmployerViewModel(e.Employer)
                                            {
                                                Avatar = _fileService.GetStaticFileUrlForFile(e.Employer.Avatar, FilePath.Avatar)
                                            }
                                        })
                                        .Future();

            var jobs = await jobsQuery.PaginateAsync<RecruimentNews, RecruimentNewsViewModel>(request);

            return View(new JobsPageViewModel
            {
                TopRecruimentNews = await hotJobsQuery.ToListAsync(),
                SearchResult = jobs
            });
        }
    }
}
