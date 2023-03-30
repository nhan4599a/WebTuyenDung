namespace WebTuyenDung.Models
{
    public class BasePostEntity : BaseEntity
    {
        public string? AdminNote { get; set; }

        public bool IsApproved { get; set; }

        public int View { get; set; }
    }
}
