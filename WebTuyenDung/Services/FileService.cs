using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Services
{
    public class FileService
    {
        private readonly string _basePath;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _basePath = webHostEnvironment.WebRootPath + "/Files/";
        }

        public async Task<string> SaveAsync(IFormFile file, FilePath filePath)
        {
            var fileName = Guid.NewGuid().ToString() + file.GetExtension();
            var actualFilePath = GetActualFilePath(fileName, filePath);
            using var fileStream = File.Create(actualFilePath);
            await file.CopyToAsync(fileStream);
            return fileName;
        }

        public string GetActualFilePath(string fileName, FilePath filePath)
        {
            return _basePath + filePath.GetContentDirectory() + fileName;
        }
    }
}
