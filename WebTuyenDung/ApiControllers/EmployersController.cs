using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.Admin;

namespace WebTuyenDung.ApiControllers
{
    public class EmployersController : BaseApiController
    {
        public EmployersController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet]
        public Task<IPaginationResult<EmployerViewModel>> Search([FromQuery] SearchRequest searchRequest)
        {
            IQueryable<Employer> query = DbContext.Employers.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchRequest.Keyword))
            {
                query = query.Where(e => e.Username.Contains(searchRequest.Keyword.Trim()));
            }

            return query.PaginateAsync<Employer, EmployerViewModel>(searchRequest);
        }

        [HttpPatch("make-as-paid/{id}")]
        public async Task<IActionResult> MakeAsPaid([FromRoute] int id)
        {
            var transaction = await DbContext.Database.BeginTransactionAsync();

            var count = await DbContext
                                .Debt
                                .Where(e => e.EmployerId == id)
                                .UpdateFromQueryAsync(e => new EmployerDebt
                                {
                                    Balance = 0
                                });

            await DbContext.Employers.Where(e => e.Id == id).UpdateFromQueryAsync(e => new Employer
            {
                LockedOutAt = null
            });

            await transaction.CommitAsync();

            return count == 1 ? Ok() : NotFound();
        }
    }
}
