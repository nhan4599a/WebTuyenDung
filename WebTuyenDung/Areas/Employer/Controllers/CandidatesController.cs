using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.ViewModels;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Areas.Employer.Controllers
{
    public class CandidatesController : BaseEmployerController
    {
        private readonly RecruimentDbContext _dbContext;

        public CandidatesController(RecruimentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            var jobs = await _dbContext.RecruimentNews
                                        .Where(e => e.EmployerId == userId)
                                        .Select(e => e.Position)
                                        .Distinct()
                                        .ToArrayAsync();

            var result = new Dictionary<JobPosition, PotentialCandidateViewModel[]>();

            foreach (var job in jobs)
            {
                var candidates = await _dbContext.PotentialCandidateCount
                                                    .Where(e => e.JobPosition == job)
                                                    .OrderByDescending(e => e.Count)
                                                    .Take(3)
                                                    .Select(e => e.Candidate)
                                                    .ProjectToType<PotentialCandidateViewModel>()
                                                    .ToArrayAsync();

                result.Add(job, candidates);
            }

            return View(result);
        }
    }
}
