using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Services
{
    public class ImageService
    {
        private readonly string _basePath;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _basePath = webHostEnvironment.WebRootPath + "/Images/";
        }

        public async Task<string> SaveAsync(IFormFile file, ImagePath imagePath)
        {
            var fileName = Guid.NewGuid().ToString() + file.GetExtension();
            var filePath = GetActualImagePath(fileName, imagePath);
            using var imageFileStream = File.Create(filePath);
            await file.CopyToAsync(imageFileStream);
            return fileName;
        }

        public string GetActualImagePath(string imageFileName, ImagePath imagePath)
        {
            return _basePath + imagePath.GetContentDirectory() + imageFileName;
        }
    }
}
