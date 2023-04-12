using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
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

        [Route("my-cv")]
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

            return View();
        }

        [HttpGet("cv/{id}")]
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

            var actualCvPath = _fileService.GetStaticFileUrlForFile(queryResult.FilePath, FilePath.CurriculumTitae);

            return RedirectPermanent(actualCvPath);
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
                    IsUploadDirectlyByUser = true
                });

            await DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
