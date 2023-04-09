using WebTuyenDung.Enums;

namespace WebTuyenDung.Requests
{
    public class SearchJobRequest : SearchRequest
    {
        public JobType? JobType { get; set; }
    }
}
