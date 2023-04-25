using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.Controllers
{
    [ControllerName("cv")]
    [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
    public class CurriculumVitaeController : BaseController
    {
        private readonly FileService _fileService;

        public CurriculumVitaeController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        [ActionName("my-cv")]
        public IActionResult Management()
        {
            var userId = User.GetUserId();

            var listCvs = DbContext.CVs
                                    .Where(e => e.CandidateId == userId)
                                    .ProjectToType<CurriculumVitaeViewModel>()
                                    .Select(e => new CurriculumVitaeViewModel(e)
                                    {
                                        Url = _fileService.GetStaticFileUrlForFile(e.Url, FilePath.CurriculumTitae)
                                    })
                                    .AsAsyncEnumerable();

            return View(listCvs);
        }

        [HttpGet("cv/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            if (!User.Identity!.IsAuthenticated || User.IsInRole(AuthorizationConstants.ADMIN_ROLE))
            {
                return Unauthorized();
            }

            var queryResult = await DbContext.CVs
                                        .Where(e => e.Id == id)
                                        .Select(e => new { e.FilePath, e.CandidateId })
                                        .FirstOrDefaultAsync();

            if (queryResult == null)
            {
                return NotFound();
            }

            if (User.IsInRole(AuthorizationConstants.CANDIDATE_ROLE) && queryResult.CandidateId != User.GetUserId())
            {
                return Unauthorized();
            }

            if (queryResult.FilePath == null)
            {
                return View("View");
            }
            else
            {
                var actualCvPath = _fileService.GetStaticFileUrlForFile(queryResult.FilePath, FilePath.CurriculumTitae)!;
                return RedirectPermanent(actualCvPath);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> Upload(UploadCurricilumVitaeRequest request)
        {
            var userId = User.GetUserId();

            var isNameExisted = await DbContext.CVs
                                               .AnyAsync(e => e.Name == request.Name && e.CandidateId == userId);

            if (isNameExisted)
            {
                ModelState.AddModelError("Name", "Name is already existed");
                return BadRequest(ModelState);
            }

            var cvPath = await _fileService.SaveAsync(request.CV, FilePath.CurriculumTitae);

            DbContext
                .CVs
                .Add(new CurriculumVitae
                {
                    CandidateId = userId,
                    Name = request.Name,
                    FilePath = cvPath,
                    IsUploadDirectlyByUser = true,
                    Type = CVType.File
                });

            await DbContext.SaveChangesAsync();

            return Ok();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> Create(CreateCVViewModel viewModel)
        {
            var cv = new CurriculumVitae
            {
                Name = viewModel.Name,
                CandidateId = User.GetUserId(),
                Type = CVType.DirectInput,
                IsUploadDirectlyByUser = true,
                Detail = viewModel.Adapt<CurriculumVitaeDetail>()
            };

            DbContext.CVs.Add(cv);

            await DbContext.SaveChangesAsync();

            return RedirectToAction("my-cv");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cvItem = await DbContext.CVs
                                        .Where(e => e.Id == id && e.Type == CVType.DirectInput)
                                        .ProjectToType<CurriculumVitaeDetailViewModel>()
                                        .FirstOrDefaultAsync();

            if (cvItem == null)
            {
                return NotFound();
            }

            cvItem.Id = id;

            return View(cvItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CurriculumVitaeDetailViewModel viewModel)
        {
            var transaction = await DbContext.Database.BeginTransactionAsync();

            await DbContext.CVs.Where(e => e.Id == id).UpdateFromQueryAsync(e => new CurriculumVitae { Name = viewModel.Name });

            await DbContext.CVDetails.Where(e => e.CVId == id).UpdateFromQueryAsync(e => new CurriculumVitaeDetail
            {
                ExpectedPosition = viewModel.ExpectedPosition,
                Email = viewModel.Email,
                SourceVersionControlUrl = viewModel.SourceVersionControlUrl,
                Objective = viewModel.Objective,
                Experience = viewModel.Experience,
                Skills = viewModel.Skills,
                Education = viewModel.Education,
                SoftSkills = viewModel.SoftSkills,
                Rewards = viewModel.Rewards
            });

            await transaction.CommitAsync();

            return RedirectToAction("my-cv");
        }
    }
}
