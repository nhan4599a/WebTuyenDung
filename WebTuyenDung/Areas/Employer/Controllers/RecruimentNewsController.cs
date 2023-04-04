using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Employer;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    [Route("{area}/recruiment-news/{action=Index}/{id?}")]
    public class RecruimentNewsController : BaseEmployerController
    {
        private readonly RecruimentDbContext dbContext;

        public RecruimentNewsController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<PaginationResult<RecruimentNewsViewModel>> Search(SearchRecruimentNewsRequest searchRequest)
        {
            IQueryable<RecruimentNews> query = dbContext.RecruimentNews.AsNoTracking().FilterRecruimentNewsByMode(searchRequest.Mode);

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.JobName.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync(
                            searchRequest.PageIndex,
                            searchRequest.PageSize,
                            e => new RecruimentNewsViewModel
                            {
                                Id = e.Id,
                                Title = e.JobName,
                                NumberOfCandidates = e.NumberOfCandidates,
                                CreatedAt = e.CreatedAt.GetApplicationTimeRepresentation(),
                                View = e.View,
                                Status = e.IsApproved ? "Đã duyệt" : "Chưa được duyệt",
                                Deadline = e.Deadline.GetApplicationTimeRepresentation()
                            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> Create(CreateRecruimentNewsViewModel createRecruimentNewsViewModel)
        {
            var recruimentNews = new RecruimentNews
            {
                JobName = createRecruimentNewsViewModel.JobTitle,
                Position = createRecruimentNewsViewModel.Position,
                PositionDetail = createRecruimentNewsViewModel.PositionDetail,
                JobDescription = createRecruimentNewsViewModel.JobDescription,
                JobRequirements = createRecruimentNewsViewModel.JobRequirements,
                EmployeeGender = createRecruimentNewsViewModel.Gender,
                JobType = createRecruimentNewsViewModel.JobType,
                RelativeSkills = createRecruimentNewsViewModel.RelativeSkills,
                Salary = createRecruimentNewsViewModel.Salary,
                NumberOfCandidates = createRecruimentNewsViewModel.NumberOfCandidates,
                WorkingAddress = createRecruimentNewsViewModel.WorkingAddress,
                CityId = createRecruimentNewsViewModel.City,
                EmployerId = User.GetUserId(),
                IsApproved = false
            };

            dbContext.RecruimentNews.Add(recruimentNews);

            var saveItemsCount = await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var recruimentNews = await dbContext.RecruimentNews.FirstOrDefaultAsync(e => e.Id == id);

            if (recruimentNews == null)
            {
                return NotFound();
            }

            return View(recruimentNews);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleletedItemsCount = await dbContext
                                               .RecruimentNews
                                               .Where(e => e.Id == id)
                                               .UpdateFromQueryAsync(e => new RecruimentNews
                                               {
                                                   IsDeleted = true
                                               });

            return deleletedItemsCount == 1 ? Ok() : BadRequest();
        }
    }
}