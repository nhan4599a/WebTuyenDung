using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;

namespace WebTuyenDung.Controllers
{
    [Route("cv/{action=Index}")]
    public class CurriculumVitaeController : Controller
    {
        private readonly RecruimentDbContext dbContext;
        private readonly FileService fileService;

        public CurriculumVitaeController(RecruimentDbContext dbContext, FileService fileService)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
        }

        [HttpPost]
        [Authorize(Policy = AuthorizationConstants.CANDIDATE_ONLY_POLICY)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(UploadCurricilumVitaeRequest request)
        {
            var cvPath = await fileService.SaveAsync(request.CV, FilePath.CurriculumTitae);

            dbContext
                .CVs
                .Add(new CurriculumVitae
                {
                    CandidateId = User.GetUserId(),
                    Name = request.Name,
                    FilePath = cvPath
                });

            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
