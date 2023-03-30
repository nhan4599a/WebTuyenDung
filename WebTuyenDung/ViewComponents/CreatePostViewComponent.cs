using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebTuyenDung.ViewComponents
{
    [ViewComponent]
    public class CreatePostViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}
