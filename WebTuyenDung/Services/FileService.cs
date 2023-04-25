using FastEnumUtility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Services
{
    public class FileService
    {
        private readonly string _basePath;

        private readonly HashSet<FilePath> _isFolderInitialized;

        private const string STATIC_FILES_DIRECTORY = "/Files/";

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _basePath = webHostEnvironment.WebRootPath + STATIC_FILES_DIRECTORY;
            _isFolderInitialized = new HashSet<FilePath>(FastEnum.GetValues<FilePath>().Count);
        }

        public async Task<string> SaveAsync(IFormFile file, FilePath filePath)
        {
            var fileName = Guid.NewGuid().ToString() + file.GetExtension();
            var actualFilePath = GetActualFilePath(fileName, filePath);
            using var fileStream = File.Create(actualFilePath);
            await file.CopyToAsync(fileStream);
            return fileName;
        }

        private string GetActualFilePath(string fileName, FilePath filePath)
        {
            var directory = _basePath + filePath.GetContentDirectory();
            if (!_isFolderInitialized.Contains(filePath) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                _isFolderInitialized.Add(filePath);
            }
            return directory + fileName;
        }

        public string? GetStaticFileUrlForFile(string? fileName, FilePath filePath)
        {
            if (fileName == null)
            {
                return null;
            }

            return STATIC_FILES_DIRECTORY + filePath.GetContentDirectory() + fileName;
        }
    }
}
