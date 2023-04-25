using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Employer;
using WebTuyenDung.ViewModels.Statistic;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class HomeController : BaseEmployerController
    {
        private readonly RecruimentDbContext _dbContext;

        public HomeController(RecruimentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = await StatisticAsync();
            return View(model);
        }

        private async Task<StatisticViewModel> StatisticAsync()
        {
            var employerId = User.GetUserId();

            var recruimentNewsCountQuery = _dbContext
                                                .RecruimentNews
                                                .Where(e => e.EmployerId == employerId)
                                                .GroupBy(e => e.IsApproved)
                                                .Select(e => new GroupByToCountQueryResult<bool>
                                                {
                                                    Key = e.Key,
                                                    Count = e.Count()
                                                })
                                                .Future();

            var approvedPostsCountQuery = _dbContext
                                                .Posts
                                                .Where(e => e.IsApproved && e.CreatedBy == employerId)
                                                .DeferredCount()
                                                .FutureValue();

            var candidatesCountQuery = _dbContext
                                            .JobApplications
                                            .Where(e => e.RecruimentNews.EmployerId == employerId
                                                        && e.Status != JobApplicationStatus.Passed
                                                        && e.Status != JobApplicationStatus.Rejected)
                                            .DeferredCount()
                                            .FutureValue();

            var topViewRecruimentNewsQuery = _dbContext
                                                .RecruimentNews
                                                .Where(e => e.IsApproved && e.EmployerId == employerId)
                                                .OrderByDescending(e => e.View)
                                                .Take(5)
                                                .ProjectToType<BaseRecruimentNewsViewModel>()
                                                .Future();

            var applicationsCountChartDataQuery = _dbContext
                                                        .JobApplications
                                                        .Where(e => e.Status != JobApplicationStatus.Received)
                                                        .GroupBy(e => e.CreatedAt.Month)
                                                        .Select(e => new GroupByToCountQueryResult<int>
                                                        {
                                                            Key = e.Key,
                                                            Count = e.Count()
                                                        })
                                                        .Future();

            var recruimentNewsCount = recruimentNewsCountQuery.ToDictionary(e => e.Key, e => e.Count);
            var approvedPostsCount = await approvedPostsCountQuery.ValueAsync();
            var candidatesCount = await candidatesCountQuery.ValueAsync();
            var topViewRecruimentNews = await topViewRecruimentNewsQuery.ToListAsync();
            var temp = await applicationsCountChartDataQuery.ToListAsync();
            var applicationsCountChartData = applicationsCountChartDataQuery.ToDictionary(e => e.Key, e => e.Count);

            return new StatisticViewModel
            {
                ApprovedRecruimentNews = recruimentNewsCount.GetValueOrDefault(true),
                WaitingForApproveRecruimentNews = recruimentNewsCount.GetValueOrDefault(false),
                ApprovedPosts = approvedPostsCount,
                TotalCandidates = candidatesCount,
                TopViewRecruimentNews = topViewRecruimentNews,
                ApplicationsCountChartData = applicationsCountChartData
            };
        }
    }
}
