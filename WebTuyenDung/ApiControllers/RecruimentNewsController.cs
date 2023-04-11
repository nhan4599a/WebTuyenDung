using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels.Abstraction;
using ManagementViewModels = WebTuyenDung.ViewModels.Management;
using UserViewModels = WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.ApiControllers
{
    [ControllerName("recruiment-news")]
    public class RecruimentNewsController : BaseApiController
    {
        private readonly FileService _fileService;

        public RecruimentNewsController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        [HttpGet("{employerId}")]
        public Task<IPaginationResult<UserViewModels.DetailRecruimentNewsViewModel>> GetRecruimentNews(
            int employerId, [FromQuery] PaginationRequest searchRequest)
        {
            var query = DbContext.RecruimentNews.Where(e => e.EmployerId == employerId).AsNoTracking();

            return query.PaginateAsync<RecruimentNews, UserViewModels.DetailRecruimentNewsViewModel>(searchRequest);
        }

        [HttpGet("management/{employerId?}")]
        public async Task<IPaginationResult<ManagementViewModels.MinimalRecruimentNewsViewModel>> GetRecruimentNewsManagement(
            int? employerId, [FromQuery] SearchRecruimentNewsRequest searchRequest)
        {
            var query = DbContext.RecruimentNews.FilterRecruimentNewsByMode(searchRequest.Mode).AsNoTracking();

            if (employerId.HasValue)
            {
                return await query.Where(e => e.EmployerId == employerId)
                                  .PaginateAsync<RecruimentNews, ManagementViewModels.MinimalRecruimentNewsViewModel>(searchRequest);
            }

            return await query.PaginateAsync<RecruimentNews, ManagementViewModels.RecruimentNewsViewModel>(searchRequest);
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var approvedCount = await DbContext
                                        .RecruimentNews
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new RecruimentNews
                                        {
                                            IsApproved = true
                                        });

            return approvedCount == 1 ? Ok() : BadRequest();
        }
    }
}
