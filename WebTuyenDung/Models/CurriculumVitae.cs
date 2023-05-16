﻿using Microsoft.EntityFrameworkCore;
using System;
using WebTuyenDung.Data.Configurations;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(CurriculumVitaeEntityConfiguration))]
    public class CurriculumVitae : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string FilePath { get; set; } = default!;

        public int CandidateId { get; set; }

        public DateTimeOffset LastModifiedDate { get; set; }

        public bool IsUploadDirectlyByUser { get; set; }

        public CVType Type { get; set; }

        public int LikeCount { get; set; } = default!;

        public CurriculumVitaeDetail? Detail { get; set; }
    }
}
