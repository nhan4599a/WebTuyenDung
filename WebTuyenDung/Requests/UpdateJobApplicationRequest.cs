using WebTuyenDung.Enums;

namespace WebTuyenDung.Requests
{
    public class UpdateJobApplicationRequest
    {
        public int CandidateId { get; set; }

        public JobApplicationStatus Status { get; set; }
    }
}
