using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.RecruimentNews;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
                                            SalaryRange = e.Salary,
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
                                            Deadline = e.Deadline.ToString("dd/MM/yyyy HH:mm")
                                        })
                                        .FirstOrDefaultAsync(e => e.Id == id);
            return View(recruimentNews);
        }
    }
}
