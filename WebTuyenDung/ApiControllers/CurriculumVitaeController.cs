﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebTuyenDung.Attributes;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.ApiControllers
{
    [ControllerName("cv")]
    public class CurriculumVitaeController : BaseApiController
    {
        private readonly FileService _fileService;

        public CurriculumVitaeController(RecruimentDbContext dbContext, FileService fileService) : base(dbContext)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public IAsyncEnumerable<CurriculumVitaeViewModel> GetAllCvs()
        {
            var userId = User.GetUserId();

            return DbContext.CVs
                            .Where(e => e.CandidateId == userId && e.IsUploadDirectlyByUser)
                            .ProjectToType<CurriculumVitaeViewModel>()
                            .Select(e => new CurriculumVitaeViewModel(e)
                            {
                                Url = _fileService.GetStaticFileUrlForFile(e.Url, FilePath.CurriculumTitae)
                            })
                            .AsAsyncEnumerable();
        }
    }
}
