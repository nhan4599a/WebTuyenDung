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

        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            var cvPath = await dbContext.CVs.Where(e => e.Id == id).Select(e => e.FilePath).FirstOrDefaultAsync();

            if (cvPath == null)
            {
                return NotFound();
            }

            var actualCvPath = fileService.GetStaticFileUrlForFile(cvPath, FilePath.CurriculumTitae);

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
