using Mapster;

namespace WebTuyenDung.ViewModels
{
    public class CurriculumVitaeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Url { get; set; }

        public CurriculumVitaeViewModel(CurriculumVitaeViewModel source)
        {
            source.Adapt(this);
        }

        public CurriculumVitaeViewModel() { }
    }
}
