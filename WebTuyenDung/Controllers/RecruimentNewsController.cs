using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.RecruimentNews;

namespace WebTuyenDung.Controllers
{
    [Route("recruiment-news")]
    public class RecruimentNewsController : Controller
    {
        private readonly RecruimentDbContext dbContext;
        private readonly FileService fileService;

        public RecruimentNewsController(RecruimentDbContext dbContext, FileService fileService)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
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
                                                AvatarUrl = fileService.GetStaticFileUrlForFile(e.Employer.Avatar!, FilePath.Avatar),
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
        [HttpPost("apply/{id}")]
        public async Task<IActionResult> Apply(int id, [FromForm] ApplyJobRequest request)
        {
            var candidateName = User.GetName();
            var jobTitle = await dbContext.RecruimentNews.Where(e => e.Id == id).Select(e => e.JobName).FirstOrDefaultAsync();

            if (request.CV != null)
            {
                var cvFilePath = await fileService.SaveAsync(request.CV, FilePath.CurriculumTitae);

                var transaction = await dbContext.Database.BeginTransactionAsync();

                var savedCV = new CurriculumVitae
                {
                    Name = cvFilePath[..cvFilePath.IndexOf('.')],
                    FilePath = cvFilePath,
                    CandidateId = User.GetUserId(),
                    IsUploadDirectlyByUser = false
                };

                dbContext.CVs.Add(savedCV);

                await dbContext.SaveChangesAsync();

                dbContext
                    .JobApplications
                    .Add(new JobApplication
                    {
                        CVId = savedCV.Id,
                        RecruimentNewsId = id,
                        CandidateId = User.GetUserId(),
                        Status = JobApplicationStatus.Received,
                        CandidateName = candidateName,
                        JobTitle = jobTitle!
                    });

                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            else
            {
                dbContext
                    .JobApplications
                    .Add(new JobApplication
                    {
                        CVId = request.CVId!.Value,
                        RecruimentNewsId = id,
                        CandidateId = User.GetUserId(),
                        Status = JobApplicationStatus.Received,
                        CandidateName = candidateName,
                        JobTitle = jobTitle!
                    });

                await dbContext.SaveChangesAsync();
            }

            return Redirect($"/recruiment-news/{id}");
        }
    }
}
