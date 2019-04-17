using Switch.Domain.Core.Commands;
using System;

namespace Switch.Domain.Commands.Inputs.Post
{
    public abstract class PostCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public DateTime PublishDate { get; protected set; }
        public Guid UserId { get; protected set; }
        public int GroupId { get; protected set; }
        public string ContentUrl { get; protected set; }
    }
}
