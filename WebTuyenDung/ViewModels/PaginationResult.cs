using System.Collections.Generic;

namespace WebTuyenDung.ViewModels
{
    public class PaginationResult<TResult>
    {
        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public List<TResult> Data { get; set; } = default!;

        public PaginationResult(int totalPage, int totalRecords, List<TResult> data)
        {
            TotalPages = totalPage;
            TotalRecords = totalRecords;
            Data = data;
        } 
    }
}
