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

            var queryResult = await DbContext
                                        .CVs
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
                var cvDetail = await DbContext
                                        .CVs
                                        .Where(e => e.Id == id)
                                        .ProjectToType<CurriculumVitaeDetailViewModel>()
                                        .FirstOrDefaultAsync();

                return View("View", cvDetail);
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
            var candidateId = User.GetUserId();

            var isExisted = await DbContext.CVs.AnyAsync(e => e.CandidateId == candidateId && e.Name == viewModel.Name);

            if (isExisted)
            {
                ModelState.AddModelError(nameof(viewModel.Name), "The provided name is already existed");
                return View();
            }

            var cv = new CurriculumVitae
            {
                Name = viewModel.Name,
                CandidateId = candidateId,
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
                                        .Where(e => e.Id == id)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCurriculumVitaeRequest request)
        {
            if (request.CV == null)
            {
                var transaction = await DbContext.Database.BeginTransactionAsync();

                var data = request.Data!;

                await DbContext.CVs.Where(e => e.Id == id).UpdateFromQueryAsync(e => new CurriculumVitae { Name = data.Name });

                await DbContext.CVDetails.Where(e => e.CVId == id).UpdateFromQueryAsync(e => new CurriculumVitaeDetail
                {
                    ExpectedPosition = data.ExpectedPosition,
                    Email = data.Email,
                    SourceVersionControlUrl = data.SourceVersionControlUrl,
                    Objective = data.Objective,
                    Experience = data.Experience,
                    Skills = data.Skills,
                    Education = data.Education,
                    SoftSkills = data.SoftSkills,
                    Rewards = data.Rewards
                });

                await transaction.CommitAsync();
            }
            else
            {
                await _fileService.ReplaceFileAsync(request.Url!, request.CV!, FilePath.CurriculumTitae);

                await DbContext.CVs.Where(e => e.Id == id).UpdateFromQueryAsync(e => new CurriculumVitae
                {
                    Name = request.Name!
                });
            }

            return Ok();
        }
    }
}
