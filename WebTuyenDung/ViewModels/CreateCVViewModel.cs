namespace WebTuyenDung.ViewModels
{
    public class CreateCVViewModel
    {
        public string Name { get; set; } = default!;

        public string ExpectedPosition { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string? SourceVersionControlUrl { get; set; }

        public string Introduction { get; set; } = default!;

        public string Objective { get; set; } = default!;

        public string Experience { get; set; } = default!;

        public string Skills { get; set; } = default!;

        public string Education { get; set; } = default!;

        public string SoftSkills { get; set; } = default!;

        public string Rewards { get; set; } = default!;
    }
}
