using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.Helper
{
    public static class FormFileHelper
    {
        public static string GetExtension(this IFormFile file)
        {
            return file.FileName[file.FileName.LastIndexOf('.')..];
        }
    }
}
