using Mapster;

namespace WebTuyenDung.ViewModels.Candidate
{
    public class MinimalEmployerViewModel
    {
        public int Id { get; set; }

        public string Avatar { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Site { get; set; } = default!;

        public MinimalEmployerViewModel(MinimalEmployerViewModel source)
        {
            source.Adapt(this);
        }

        public MinimalEmployerViewModel() { }
    }
}
