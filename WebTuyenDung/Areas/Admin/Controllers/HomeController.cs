using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Admin;
using WebTuyenDung.ViewModels.Statistic;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
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
            var usersCountQuery = _dbContext
                                        .Users
                                        .Where(e => e.Role != UserRole.Admin)
                                        .GroupBy(e => e.Role)
                                        .Select(e => new GroupByToCountQueryResult<UserRole>
                                        {
                                            Key = e.Key,
                                            Count = e.Count()
                                        })
                                        .Future();

            var recruimentNewsCountQuery = _dbContext
                                                .RecruimentNews
                                                .Where(e => e.IsApproved)
                                                .DeferredCount()
                                                .FutureValue();

            var postsCountQuery = _dbContext.Posts
                                            .Where(e => e.IsApproved)
                                            .DeferredCount()
                                            .FutureValue();

            var topViewRecruimentNewsQuery = _dbContext
                                                .RecruimentNews
                                                .Where(e => e.IsApproved)
                                                .OrderByDescending(e => e.View)
                                                .Take(5)
                                                .ProjectToType<RecruimentNewsViewModel>()
                                                .Future();

            var jobFoundCandidatesChartDataQuery = _dbContext
                                                        .JobApplications
                                                        .Where(e => e.Status == JobApplicationStatus.Passed)
                                                        .GroupBy(e => e.CreatedAt.Month)
                                                        .Select(e => new GroupByToCountQueryResult<int>
                                                        {
                                                            Key = e.Key,
                                                            Count = e.Count()
                                                        })
                                                        .Future();

            var numberOfUsers = usersCountQuery.ToDictionary(e => e.Key, e => e.Count);

            var numberOfCandidates = numberOfUsers.GetValueOrDefault(UserRole.Candidate);
            var numberOfEmployers = numberOfUsers.GetValueOrDefault(UserRole.Employer);
            var numberOfRecruimentNews = await recruimentNewsCountQuery.ValueAsync();
            var numberOfPosts = await postsCountQuery.ValueAsync();
            var topViewRecruimentNews = await topViewRecruimentNewsQuery.ToListAsync();
            var jobFoundCandidatesChartData = jobFoundCandidatesChartDataQuery.ToDictionary(e => e.Key, e => e.Count);

            return new StatisticViewModel
            {
                NumberOfCandidates = numberOfCandidates,
                NumberOfEmployers = numberOfEmployers,
                NumberOfRecruimentNews = numberOfRecruimentNews,
                NumberOfPosts = numberOfPosts,
                JobFoundCandidatesDataChart = jobFoundCandidatesChartData,
                TopViewRecruimentNews = topViewRecruimentNews
            };
        }
    }
}
