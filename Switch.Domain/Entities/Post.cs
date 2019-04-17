using Switch.Domain.Core.Entities;
using System;

namespace Switch.Domain.Entities
{
    public class Post : Entity
    {
        public Post(Guid id, string title, Guid userId, int groupId, string contentUrl)
        {
            Id = id;
            Title = title;
            PublishDate = DateTime.Now;
            UserId = userId;
            GroupId = groupId;
            ContentUrl = contentUrl;
        }

        protected Post() { }

        public string Title { get; private set; }
        public DateTime PublishDate { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User User { get; set; }
        public int GroupId { get; private set; }
        public virtual Group Group { get; set; }
        public string ContentUrl { get; private set; }
    }
}
