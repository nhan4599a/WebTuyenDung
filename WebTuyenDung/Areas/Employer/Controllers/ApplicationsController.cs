using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class ApplicationsController : BaseEmployerController
    {
        private readonly RecruimentDbContext _dbContext;

        public ApplicationsController(RecruimentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Edit(int id, UpdateJobApplicationRequest request, [FromServices] EmailService emailService)
        {
            var jobApplication = (await _dbContext.JobApplications.Include(e => e.RecruimentNews).FirstOrDefaultAsync(e => e.Id == id))!;
            jobApplication.Status = request.Status;

            if (request.Status == JobApplicationStatus.Potential || request.Status == JobApplicationStatus.Passed)
            {
                var countData = await _dbContext.PotentialCandidateCount
                                                .FirstOrDefaultAsync(e => e.CandidateId == request.CandidateId
                                                        && e.JobPosition == jobApplication.RecruimentNews.Position);

                if (countData == null)
                {
                    _dbContext.PotentialCandidateCount.Add(new PotentialCandidateCount
                    {
                        CandidateId = jobApplication.CandidateId,
                        JobPosition = jobApplication.RecruimentNews.Position,
                        Count = 1
                    });
                }
                else
                {
                    countData.Count += 1;
                }
            }
            _dbContext.Entry(jobApplication).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            if (request.Status != JobApplicationStatus.Potential)
            {
                var candidateInfoQuery = _dbContext.Candidates
                                                            .Where(e => e.Id == jobApplication.CandidateId)
                                                            .Select(e => new
                                                            {
                                                                e.Username,
                                                                e.Name
                                                            })
                                                            .DeferredFirstOrDefault();

                var emailQuery = _dbContext.CVs
                                            .Where(e => e.Id == jobApplication.CVId && e.Type == CVType.DirectInput)
                                            .Select(e => e.Detail!.Email)
                                            .DeferredFirstOrDefault();

                var candidateInfo = await candidateInfoQuery.ExecuteAsync();
                var email = await emailQuery.ExecuteAsync();

                var sendMailRequest = BuildSendMailRequest(email ?? candidateInfo!.Username, candidateInfo!.Name, jobApplication.RecruimentNewsId, jobApplication.JobName, request.Status);

                await emailService.SendAsync(sendMailRequest);
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> View(int id)
        {
            var jobApplication = await TryGetAndUpdateJobApplication(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return Redirect($"/cv/{jobApplication.CVId}");
        }

        private async Task<JobApplication?> TryGetAndUpdateJobApplication(int id)
        {
            var jobApplication = await _dbContext.JobApplications.FirstOrDefaultAsync(e => e.Id == id);

            if (jobApplication != null && jobApplication.Status == JobApplicationStatus.Received)
            {
                jobApplication.Status = JobApplicationStatus.Seen;
                _dbContext.Entry(jobApplication).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            return jobApplication;
        }

        private SendMailRequest BuildSendMailRequest(
            string candidateEmail,
            string candidateName,
            int jobId,
            string jobName,
            JobApplicationStatus status)
        {
            string subject = $"Thư thông báo kết quả tuyển dụng - {candidateName}";
            string body;

            if (status == JobApplicationStatus.Scheduled)
            {
                var scheduledTime = DateTime.Now.AddDays(7);
                var scheduledTimeRepresentation = $"09:00 AM thứ {((int)scheduledTime.DayOfWeek) + 1} ngày {scheduledTime:dd/MM/yyyy}";
                body = $"Nhà tuyển dụng \"{User.GetName()}\" đã duyệt qua đơn ứng tuyển cho công việc <a href=\"https://localhost:5000/recruiment-news/{jobId}\">{jobName}</a> của bạn và mời bạn phỏng vấn vào lúc {scheduledTimeRepresentation} tại địa chỉ công ty ở {User.GetAddress()}";
            }
            else if (status == JobApplicationStatus.Passed)
            {
                body = $"Kết quả tuyển dụng cho công việc cho công việc <a href=\"https://localhost:5000/recruiment-news/{jobId}\">{jobName}</a> mà bạn đã ứng tuyển từ nhà tuyển dụng \"{User.GetName()}\" là: đã đậu phỏng vấn";
            }
            else
            {
                body = $"Kết quả tuyển dụng cho công việc cho công việc <a href=\"https://localhost:5000/recruiment-news/{jobId}\">{jobName}</a> mà bạn đã ứng tuyển từ nhà tuyển dụng \"{User.GetName()}\" là: đã trượt phỏng vấn";
            }

            return new SendMailRequest
            {
                ToAddress = candidateEmail,
                Subject = subject,
                Body = body,
                IsHTMLBody = true
            };
        }
    }
}
