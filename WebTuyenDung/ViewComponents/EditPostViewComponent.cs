using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTuyenDung.Models;

namespace WebTuyenDung.ViewComponents
{
    [ViewComponent]
    public class EditPostViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Post post)
        {
            return Task.FromResult((IViewComponentResult)View(post));
        }
    }
}
