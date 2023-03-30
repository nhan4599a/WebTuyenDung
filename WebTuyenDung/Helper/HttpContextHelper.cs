using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace WebTuyenDung.Helper
{
    public static class HttpContextHelper
    {
        public static ITempDataDictionary GetTempData(this HttpContext httpContext)
        {
            var tempDataFactory = httpContext.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
            return tempDataFactory.GetTempData(httpContext);
        }
    }
}
