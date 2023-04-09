using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.Page;

namespace WebTuyenDung.Controllers
{
    public class EmployersController : BaseController
    {
        private readonly FileService _fileService;

        public EmployersController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService  = fileService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var viewModel = await DbContext.Employers
                                            .Where(e => e.Id == id)
                                            .ProjectToType<DetailEmployerPageViewModel>()
                                            .Select(e => new DetailEmployerPageViewModel(e)
                                            {
                                                Avatar = _fileService.GetStaticFileUrlForFile(e.Avatar, FilePath.Avatar)
                                            })
                                            .FirstOrDefaultAsync();

            return View(viewModel);
        }
    }
}
