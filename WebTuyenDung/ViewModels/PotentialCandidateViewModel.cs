using System.Collections.Generic;

namespace WebTuyenDung.ViewModels
{
    public class PotentialCandidateViewModel
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public List<CurriculumVitaeViewModel> CVs { get; set; } = default!;
    }
}
