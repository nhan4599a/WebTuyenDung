using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Employer;
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
        public async Task<IActionResult> Edit(int id, UpdateJobApplicationRequest request)
        {
            var jobApplication = (await _dbContext.JobApplications.Include(e => e.RecruimentNews).FirstOrDefaultAsync(e => e.Id == id))!;
            jobApplication.Status = request.Status;

            _dbContext.Notifications.Add(new Notification
            {
                RecruimentNewsId = jobApplication.RecruimentNewsId,
                CandidateId = jobApplication.CandidateId,
                Message = $"{User.GetName()} đã chuyển trạng thái đơn ứng tuyển của bạn sang {request.Status.GetRepresentation()}"
            });

            if (request.Status == JobApplicationStatus.Passed)
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
    }
}
