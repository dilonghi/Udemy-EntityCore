using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
