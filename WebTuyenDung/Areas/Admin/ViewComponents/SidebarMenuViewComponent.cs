using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Data;

namespace WebTuyenDung.Areas.Admin.ViewComponents
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        private readonly RecruimentDbContext dbContext;

        public SidebarMenuViewComponent(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}
