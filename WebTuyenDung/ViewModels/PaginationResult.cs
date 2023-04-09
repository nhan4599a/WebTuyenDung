using System.Collections.Generic;

namespace WebTuyenDung.ViewModels
{
    public class PaginationResult<TResult>
    {
        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public List<TResult> Data { get; set; } = default!;

        public PaginationResult(int totalPages, int totalRecords, List<TResult> data)
        {
            TotalPages = totalPages;
            TotalRecords = totalRecords;
            Data = data;
        } 
    }
}
