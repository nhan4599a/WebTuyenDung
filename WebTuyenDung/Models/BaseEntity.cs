using System;

namespace WebTuyenDung.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
