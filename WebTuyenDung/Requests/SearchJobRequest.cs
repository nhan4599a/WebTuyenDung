using WebTuyenDung.Enums;

namespace WebTuyenDung.Requests
{
    public class SearchJobRequest : SearchRequest
    {
        public JobPosition? Position { get; set; }

        public JobType? JobType { get; set; }

        public string? Salary { get; set; }
    }
}
