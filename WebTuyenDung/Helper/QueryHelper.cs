using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Enums;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Abstraction;
using Z.EntityFramework.Plus;
using UserViewModels = WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.Helper
{
    public static class QueryHelper
    {
        public static async Task<IPaginationResult<TResult>> PaginateAsync<TSource, TResult>(
            this IQueryable<TSource> query, PaginationRequest request) where TSource : BaseEntity
        {
            var futureCount = query.DeferredCount().FutureValue();
            var futureData = query.AsNoTracking()
                                .OrderBy(e => e.CreatedAt)
                                .Skip((request.PageIndex - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .ProjectToType<TResult>()
                                .Future();

            var data = await futureData.ToListAsync();
            var count = await futureCount.ValueAsync();

            var totalPages = (data.Count == 0 || count == 0) ? 1 : Math.Ceiling((count * 1.0) / request.PageSize);

            return new PaginationResult<TResult>((int)totalPages, count, data);
        }

        public static IQueryable<RecruimentNews> FilterRecruimentNewsByMode(
            this IQueryable<RecruimentNews> query, SearchRecruimentNewsMode mode)
        {
            return mode switch
            {
                SearchRecruimentNewsMode.Approved => query.Where(e => e.IsApproved),
                SearchRecruimentNewsMode.WaitForApprove => query.Where(e => !e.IsApproved),
                SearchRecruimentNewsMode.OutOfApplicableTime => query.Where(e => e.Deadline.HasValue && e.Deadline < DateTimeHelper.Today),
                _ => throw new NotSupportedException()
            };
        }

        public static IQueryable<TRecruimentNewsViewModel> QueryTopItems<TRecruimentNewsViewModel>(
            this IQueryable<RecruimentNews> query,
            int top)
        {
            return query.AsNoTracking()
                        .OrderByDescending(e => e.CreatedAt)
                        .Take(top)
                        .ProjectToType<TRecruimentNewsViewModel>();
        }

        public static IQueryable<UserViewModels.PostViewModel> QueryTopItems(
            this IQueryable<Post> query,
            int top,
            FileService fileService)
        {
            return query.AsNoTracking()
                        .Where(e => e.IsApproved)
                        .OrderByDescending(e => e.CreatedAt)
                        .Take(top)
                        .ProjectToType<UserViewModels.PostViewModel>()
                        .Select(e => new UserViewModels.PostViewModel(e)
                        {
                            Image = fileService.GetStaticFileUrlForFile(e.Image, FilePath.Post)
                        });
        }
    }
}
