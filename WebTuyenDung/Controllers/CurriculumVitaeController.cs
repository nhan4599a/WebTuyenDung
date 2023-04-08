using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    [Route("cv")]
    [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
    public class CurriculumVitaeController : BaseController
    {
        private readonly RecruimentDbContext dbContext;
        private readonly FileService fileService;

        public CurriculumVitaeController(RecruimentDbContext dbContext, FileService fileService)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
        }

        public IAsyncEnumerable<CurriculumVitaeViewModel> Index()
        {
            var userId = User.GetUserId();

            return dbContext.CVs
                            .Where(e => e.CandidateId == userId && e.IsUploadDirectlyByUser)
                            .Select(e => new CurriculumVitaeViewModel
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Url = fileService.GetStaticFileUrlForFile(e.FilePath, FilePath.CurriculumTitae)
                            })
                            .AsAsyncEnumerable();
        }

        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            if (!User.Identity!.IsAuthenticated || User.IsInRole(AuthorizationConstants.ADMIN_ROLE))
            {
                return Unauthorized();
            }

            var queryResult = await dbContext.CVs
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

            var actualCvPath = fileService.GetStaticFileUrlForFile(queryResult.FilePath, FilePath.CurriculumTitae);

            return RedirectPermanent(actualCvPath);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutoShortCircuitValidationFailedRequest]
        public async Task<IActionResult> Upload(UploadCurricilumVitaeRequest request)
        {
            var cvPath = await fileService.SaveAsync(request.CV, FilePath.CurriculumTitae);

            dbContext
                .CVs
                .Add(new CurriculumVitae
                {
                    CandidateId = User.GetUserId(),
                    Name = request.Name,
                    FilePath = cvPath,
                    IsUploadDirectlyByUser = true
                });

            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
