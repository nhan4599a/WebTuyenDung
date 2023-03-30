namespace WebTuyenDung.Requests
{
    public class SearchPostsRequest : SearchRequest
    {
        public bool IsApproved { get; set; } = true;
    }
}
