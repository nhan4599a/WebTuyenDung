using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.RecruimentNews;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebTuyenDung.Helper;
using WebTuyenDung.Requests;
using Microsoft.AspNetCore.Authorization;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Controllers
{
    [Route("recruiment-news")]
    public class RecruimentNewsController : Controller
    {
        private readonly RecruimentDbContext dbContext;

        public RecruimentNewsController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var recruimentNews = await dbContext
                                        .RecruimentNews
                                        .Select(e => new DetailRecruimentNewsViewModel
                                        {
                                            Id = e.Id,
                                            Salary = e.Salary,
                                            Gender = e.EmployeeGender.GetRepresentation(),
                                            JobType = e.JobType.GetRepresentation(),
                                            JobTitle = e.JobName,
                                            RelativeSkills = e.RelativeSkills,
                                            Description = e.JobDescription,
                                            Employer = new EmployerViewModel
                                            {
                                                Id = e.Employer.Id,
                                                Name = e.Employer.Name,
                                                Address = e.WorkingAddress,
                                                AvatarUrl = e.Employer.Avatar!,
                                                Description = e.Employer.Description,
                                                Size = e.Employer.Size
                                            },
                                            Deadline = e.Deadline.GetApplicationTimeRepresentation()
                                        })
                                        .FirstOrDefaultAsync(e => e.Id == id);

            if (recruimentNews == null)
            {
                return NotFound();
            }

            return View(recruimentNews);
        }

        [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
        [HttpPost]
        public async Task<IActionResult> Apply(int id, [FromForm] ApplyJobRequest request)
        {

            return View();
        }
    }
}
