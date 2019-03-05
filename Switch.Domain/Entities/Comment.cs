using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; private set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; private set; }

        public Comment()
        {
            PublishDate = DateTime.Now;
        }

        public void SetUser(User user)
        {
            if (user != null)
                User = user;
        }
    }
}
