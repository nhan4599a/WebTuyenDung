﻿using Mapster;
using Microsoft.AspNetCore.Http;
using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.User
{
    public class CurriculumVitaeDetailViewModel
    {
        [AdaptIgnore]
        public int Id { get; set; }

        [AdaptIgnore]
        public IFormFile? ImageFile { get; set; }

        public string Image { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string BirthDay { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Address { get; set; } = default!;

        public Gender Gender { get; set; }

        public string ExpectedPosition { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string? SourceVersionControlUrl { get; set; }

        public string Introduction { get; set; } = default!;

        public string Objective { get; set; } = default!;

        public string Experience { get; set; } = default!;

        public string Skills { get; set; } = default!;

        public string Education { get; set; } = default!;

        public string SoftSkills { get; set; } = default!;
    }
}
