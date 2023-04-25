using System;

namespace WebTuyenDung.ViewModels.Statistic
{
    public class BaseRecruimentNewsViewModel
    {
        public string JobName { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; } = default!;

        public int View { get; set; }
    }
}
