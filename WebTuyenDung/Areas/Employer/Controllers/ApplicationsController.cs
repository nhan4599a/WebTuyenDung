﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Controllers;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Employer;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class ApplicationsController : BaseEmployerController
    {
        private readonly RecruimentDbContext dbContext;

        public ApplicationsController(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public Task<PaginationResult<JobApplicationViewModel>> Search(SearchRequest request)
        {
            var query = dbContext
                            .JobApplications
                            .AsNoTracking();

            return query.PaginateAsync(
                            request.PageIndex,
                            request.PageSize,
                            e => new JobApplicationViewModel
                            {
                                Id = e.Id,
                                RecruimentNewsId = e.RecruimentNewsId,
                                JobTitle = e.JobTitle,
                                CandidateName = e.CandidateName,
                                CVId = e.CVId,
                                CreatedAt = e.CreatedAt.GetApplicationTimeRepresentation(),
                                Status = e.Status.GetRepresentation()
                            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var jobApplication = await TryGetAndUpdateJobApplication(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobApplication jobApplication)
        {
            var updatedCount = await dbContext
                                        .JobApplications
                                        .Where(e => e.Id == id)
                                        .UpdateFromQueryAsync(e => new JobApplication
                                        {
                                            Status = jobApplication.Status
                                        });

            return updatedCount == 0 ? BadRequest() : RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> View(int id)
        {
            var jobApplication = await TryGetAndUpdateJobApplication(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return RedirectPermanent($"/cv/{jobApplication.CVId}");
        }

        private async Task<JobApplication?> TryGetAndUpdateJobApplication(int id)
        {
            var jobApplication = await dbContext.JobApplications.FirstOrDefaultAsync(e => e.Id == id);

            if (jobApplication != null && jobApplication.Status == JobApplicationStatus.Received)
            {
                jobApplication.Status = JobApplicationStatus.Seen;
                await dbContext.SaveChangesAsync();
            }

            return jobApplication;
        }
    }
}
