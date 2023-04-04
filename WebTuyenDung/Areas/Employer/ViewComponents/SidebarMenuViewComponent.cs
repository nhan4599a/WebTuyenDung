using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Employer.ViewComponents
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        private readonly RecruimentDbContext dbContext;

        public SidebarMenuViewComponent(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = (User as ClaimsPrincipal)!.GetUserId();

            var waitForApprovalRecruimentNewsCount = dbContext
                                                        .RecruimentNews
                                                        .DeferredCount(e => !e.IsApproved && e.EmployerId == userId)
                                                        .FutureValue();

            var waitForApprovalPostsCount = dbContext
                                                .Posts
                                                .DeferredCount(e => !e.IsApproved && e.CreatedBy == userId)
                                                .FutureValue();

            ViewData[ViewConstants.WAIT_FOR_APPROVAL_RECRUIMENT_NEWS] = await waitForApprovalRecruimentNewsCount.ValueAsync();
            ViewData[ViewConstants.WAIT_FOR_APPROVAL_POSTS] = await waitForApprovalPostsCount.ValueAsync();

            return View();
        }
    }
}
