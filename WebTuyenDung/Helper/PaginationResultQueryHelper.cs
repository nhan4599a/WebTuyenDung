using System;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.Helper
{
    public static class PaginationResultQueryHelper
    {
        public static async Task<IPaginationResult<TResult>> Select<TSource, TResult>(
            this Task<IPaginationResult<TSource>> source, Func<TSource, TResult> selector)
        {
            var sourceResult = await source;

            return new PaginationResult<TResult>(sourceResult.TotalPages, sourceResult.TotalRecords, sourceResult.Data.Select(selector));
        }
    }
}
