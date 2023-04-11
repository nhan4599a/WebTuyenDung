using System.Collections.Generic;
using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.ViewModels
{
    public class PaginationResult<TResult> : IPaginationResult<TResult>
    {
        public int TotalPages { get; }

        public int TotalRecords { get; }

        public IEnumerable<TResult> Data { get; }

        public PaginationResult(int totalPages, int totalRecords, IEnumerable<TResult> data)
        {
            TotalPages = totalPages;
            TotalRecords = totalRecords;
            Data = data;
        }
    }
}
