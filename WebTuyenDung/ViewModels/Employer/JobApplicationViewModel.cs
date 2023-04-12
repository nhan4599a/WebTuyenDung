﻿using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.Employer
{
    public class JobApplicationViewModel
    {
        public int Id { get; set; }

        public int RecruimentNewsId { get; set; }

        public string JobName { get; set; } = default!;

        public string CandidateName { get; set; } = default!;

        public int CVId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public JobApplicationStatus Status { get; set; }
    }
}
