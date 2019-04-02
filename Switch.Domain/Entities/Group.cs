using Switch.Domain.Core.Entities;
using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
