using System.Collections.Generic;

namespace WebTuyenDung.ViewModels.Abstraction
{
    public interface IPaginationResult<out TResult>
    {
        public int TotalPages { get; }

        public int TotalRecords { get; }

        public IEnumerable<TResult> Data { get; }
    }
}
