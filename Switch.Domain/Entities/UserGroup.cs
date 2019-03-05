using System;

namespace Switch.Domain.Entities
{
    public class UserGroup
    {
        public DateTime CreateDate { get; set; }
        public bool IsAdmin { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
