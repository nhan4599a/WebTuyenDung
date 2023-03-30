namespace WebTuyenDung.Requests
{
    public class SearchRequest
    {
        public string Keyword { get; set; } = default!;

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
