using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Admin.ViewComponents
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
            var waitForApprovalRecruimentNewsCount = dbContext
                                                        .RecruimentNews
                                                        .DeferredCount(e => !e.IsApproved)
                                                        .FutureValue();

            var waitForApprovalPostsCount = dbContext
                                                .Posts
                                                .DeferredCount(e => !e.IsApproved)
                                                .FutureValue();

            ViewData[ViewConstants.WAIT_FOR_APPROVAL_RECRUIMENT_NEWS] = await waitForApprovalRecruimentNewsCount.ValueAsync();
            ViewData[ViewConstants.WAIT_FOR_APPROVAL_POSTS] = await waitForApprovalPostsCount.ValueAsync();

            return View();
        }
    }
}
