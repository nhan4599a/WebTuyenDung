using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Requests
{
    public class CandidateSignUpRequest : BaseSignUpRequest
    {
        public DateOnly BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
