using System;

namespace Switch.Appilcation.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }
        public int GroupId { get; set; }
        public string ContentUrl { get; set; }
    }
}
