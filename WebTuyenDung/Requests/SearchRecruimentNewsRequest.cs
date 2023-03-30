namespace WebTuyenDung.Requests
{
    public class SearchRecruimentNewsRequest : SearchRequest
    {
        public SearchRecruimentNewsMode Mode { get; set; }
    }

    public enum SearchRecruimentNewsMode
    {
        Approved,
        WaitForApprove,
        OutOfApplicableTime
    }
}
