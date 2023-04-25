using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.User;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Controllers
{
    [ControllerName("recruiment-news")]
    public class RecruimentNewsController : BaseController
    {
        private readonly FileService _fileService;

        public RecruimentNewsController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        [HttpGet("{controller}/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var recruimentNewsQuery = DbContext.RecruimentNews
                                                .ProjectToType<FullDetailRecruimentNewsViewModel>()
                                                .DeferredFirstOrDefault(e => e.Id == id)
                                                .FutureValue();

            var candidateId = User.GetUserId();
            var isJobSaved = await DbContext
                                        .SavedRecruimentNews
                                        .DeferredAny(e => e.RecruimentNewsId == id && e.CandidateId == candidateId)
                                        .FutureValue()
                                        .ValueAsync();

            var recruimentNews = await recruimentNewsQuery.ValueAsync();

            if (recruimentNews == null)
            {
                return NotFound();
            }

            recruimentNews.Employer.Avatar = _fileService.GetStaticFileUrlForFile(recruimentNews.Employer.Avatar, FilePath.Avatar)!;
            recruimentNews.IsSaved = isJobSaved;

            return View(recruimentNews);
        }

        [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
        [ActionName("apply")]
        public async Task<IActionResult> Apply(int id, [FromForm] ApplyJobRequest request)
        {
            var candidateName = User.GetName();
            var jobName = await DbContext.RecruimentNews.Where(e => e.Id == id).Select(e => e.JobName).FirstOrDefaultAsync();

            if (request.CV != null)
            {
                var cvFilePath = await _fileService.SaveAsync(request.CV, FilePath.CurriculumTitae);

                var transaction = await DbContext.Database.BeginTransactionAsync();

                var savedCV = new CurriculumVitae
                {
                    Name = $"{candidateName} - {jobName} - {DateTime.Now:dd/MM/yyyy}",
                    FilePath = cvFilePath,
                    CandidateId = User.GetUserId(),
                    IsUploadDirectlyByUser = false,
                    Type = CVType.File
                };

                DbContext.CVs.Add(savedCV);

                await DbContext.SaveChangesAsync();

                DbContext
                    .JobApplications
                    .Add(new JobApplication
                    {
                        CVId = savedCV.Id,
                        RecruimentNewsId = id,
                        CandidateId = User.GetUserId(),
                        Status = JobApplicationStatus.Received,
                        CandidateName = candidateName,
                        JobName = jobName!
                    });

                await DbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            else
            {
                DbContext
                    .JobApplications
                    .Add(new JobApplication
                    {
                        CVId = request.CVId!.Value,
                        RecruimentNewsId = id,
                        CandidateId = User.GetUserId(),
                        Status = JobApplicationStatus.Received,
                        CandidateName = candidateName,
                        JobName = jobName!
                    });

                await DbContext.SaveChangesAsync();
            }

            TempData["alert"] = "Ứng tuyển thành công";

            return Redirect($"/recruiment-news/{id}");
        }
    }
}
