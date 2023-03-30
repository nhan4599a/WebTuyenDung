using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using Z.EntityFramework.Plus;

namespace WebTuyenDung.Helper
{
    public static class QueryHelper
    {
        public static async Task<PaginationResult<TResult>> PaginateAsync<TSource, TResult>(
            this IQueryable<TSource> query,
            int pageIndex,
            int pageSize,
            Expression<Func<TSource, TResult>> expression) where TSource : BaseEntity
        {
            var futureCount = query.DeferredCount().FutureValue();
            var futureData = query
                                .OrderBy(e => e.CreatedAt)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .Select(expression)
                                .Future();

            var data = await futureData.ToListAsync();
            var count = futureCount.Value;

            var totalPages = (data.Count == 0 || count == 0) ? 0 : Math.Ceiling(((double)data.Count) / count);

            return new PaginationResult<TResult>((int)totalPages, count, data);
        }

        public static IQueryable<RecruimentNews> FilterRecruimentNewsByMode(
            this IQueryable<RecruimentNews> query, SearchRecruimentNewsMode mode)
        {
            return mode switch
            {
                SearchRecruimentNewsMode.Approved => query.Where(e => e.IsApproved),
                SearchRecruimentNewsMode.WaitForApprove => query.Where(e => !e.IsApproved),
                SearchRecruimentNewsMode.OutOfApplicableTime => query.Where(e => e.Deadline < DateTimeHelper.Today),
                _ => throw new NotSupportedException()
            };
        }
    }
}
