using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Management;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    [ControllerName("recruiment-news")]
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
        public Task<IPaginationResult<MinimalRecruimentNewsViewModel>> Search(SearchRecruimentNewsRequest searchRequest)
        {
            IQueryable<RecruimentNews> query = dbContext.RecruimentNews.AsNoTracking().FilterRecruimentNewsByMode(searchRequest.Mode);

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
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> Create(CreateRecruimentNewsViewModel createRecruimentNewsViewModel)
        {
            var (MinimumSalary, MaximumSalary) = SalaryHelper.ParseSalary(createRecruimentNewsViewModel.Salary);

            var recruimentNews = createRecruimentNewsViewModel.Adapt<RecruimentNews>();
            recruimentNews.MinimumSalary = MinimumSalary;
            recruimentNews.MaximumSalary = MaximumSalary;
            recruimentNews.EmployerId = User.GetUserId();

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