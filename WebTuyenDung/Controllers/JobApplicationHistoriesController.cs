using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.Controllers
{
    [ControllerName("job-application-histories")]
    public class JobApplicationHistoriesController : BaseController
    {
        private readonly FileService _fileService;

        public JobApplicationHistoriesController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var userId = User.GetUserId();

            var model = DbContext
                            .JobApplications
                            .Where(e => e.CandidateId == userId)
                            .ProjectToType<JobApplicationHistoryViewModel>()
                            .AsNoTracking()
                            .Select(e => new JobApplicationHistoryViewModel(e)
                            {
                                EmployerAvatar = _fileService.GetStaticFileUrlForFile(e.EmployerAvatar, FilePath.Avatar)!
                            })
                            .AsAsyncEnumerable();

            return View(model);
        }
    }
}
