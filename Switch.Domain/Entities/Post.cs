using Switch.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string ContentUrl { get; set; }
    }
}
