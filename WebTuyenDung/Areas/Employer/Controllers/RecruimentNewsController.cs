using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Management;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    [ControllerName("recruiment-news")]
    public class RecruimentNewsController : BaseEmployerController
    {
        private readonly RecruimentDbContext _dbContext;

        public RecruimentNewsController(RecruimentDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<IPaginationResult<MinimalRecruimentNewsViewModel>> Search(SearchRecruimentNewsRequest searchRequest)
        {
            IQueryable<RecruimentNews> query = _dbContext.RecruimentNews.AsNoTracking().FilterRecruimentNewsByMode(searchRequest.Mode);

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.JobName.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync<RecruimentNews, MinimalRecruimentNewsViewModel>(searchRequest);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrUpdateRecruimentNewsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var recruimentNews = request.Adapt<RecruimentNews>();

            if (request.Salary != "Khác" && request.Salary != "Thỏa thuận")
            {
                var (MinimumSalary, MaximumSalary) = SalaryHelper.ParseSalary(request.Salary);

                recruimentNews.MinimumSalary = MinimumSalary;
                recruimentNews.MaximumSalary = MaximumSalary;
            }

            var employerId = User.GetUserId();

            recruimentNews.EmployerId = employerId;

            _dbContext.RecruimentNews.Add(recruimentNews);

            var saveItemsCount = await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var recruimentNews = await _dbContext.RecruimentNews.FirstOrDefaultAsync(e => e.Id == id);

            if (recruimentNews == null)
            {
                return NotFound();
            }

            return View(recruimentNews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateOrUpdateRecruimentNewsRequest request)
        {
            var updatedCount = await _dbContext
                                        .RecruimentNews
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new RecruimentNews
                                        {
                                            JobName = request.JobName,
                                            Position = request.Position,
                                            PositionDetail = request.PositionDetail,
                                            JobType = request.JobType,
                                            Salary = request.Salary,
                                            MinimumSalary = request.MinimumSalary,
                                            MaximumSalary = request.MaximumSalary,
                                            CityId = request.CityId,
                                            DistrictId = request.DistrictId,
                                            WardId = request.WardId,
                                            WorkingAddress = request.WorkingAddress,
                                            JobDescription = request.JobDescription,
                                            JobRequirements = request.JobRequirements,
                                            RelativeSkills = request.RelativeSkills,
                                            Benefit = request.Benefit,
                                            NumberOfCandidates = request.NumberOfCandidates,
                                            EmployeeGender = request.Gender,
                                            Deadline = request.Deadline
                                        });

            if (updatedCount == 0)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}