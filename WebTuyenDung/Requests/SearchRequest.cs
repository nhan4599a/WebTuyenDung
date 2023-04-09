namespace WebTuyenDung.Requests
{
    public class SearchRequest : PaginationRequest
    {
        public string Keyword { get; set; } = default!;
    }
}
