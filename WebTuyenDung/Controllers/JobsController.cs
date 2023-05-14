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

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] SearchJobRequest request)
        {
            IQueryable<RecruimentNews> baseQuery = DbContext.RecruimentNews.AsNoTracking();
            IQueryable<RecruimentNews> query = baseQuery;

            if (request.JobType != null)
            {
                query = query.Where(e => e.JobType == request.JobType);
            }
            if (request.Position != null)
            {
                query = query.Where(e => e.Position == request.Position);
            }
            if (!string.IsNullOrWhiteSpace(request.Salary))
            {
                var (minSalary, maxSalary) = SalaryHelper.ParseSalary(request.Salary);
                query = query.Where(e => e.MinimumSalary >= minSalary || e.MaximumSalary <= maxSalary);
            }

            var hotJobsQuery = baseQuery.QueryTopItems<TopJobsViewModel>(5)
                                        .Select(e => new TopJobsViewModel(e)
                                        {
                                            Employer = new BaseEmployerViewModel(e.Employer)
                                            {
                                                Avatar = _fileService.GetStaticFileUrlForFile(e.Employer.Avatar, FilePath.Avatar)!
                                            }
                                        })
                                        .Future();

            var jobs = await query.PaginateAsync<RecruimentNews, DetailRecruimentNewsViewModel>(request)
                                      .Select(e => new DetailRecruimentNewsViewModel(e)
                                      {
                                          Employer = new BaseEmployerViewModel(e.Employer)
                                          {
                                              Avatar = _fileService.GetStaticFileUrlForFile(e.Employer.Avatar, FilePath.Avatar)!
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
