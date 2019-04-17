using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Switch.Domain.Interfaces.Repositories
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<Post> GetAllPostsByUserId(Guid userId);
        IEnumerable<Post> GetAllPostsByGroupId(int groupId);
        IQueryable<Post> GetAll();
        Post GetById(Guid id);
        Post GetPostByTitleAndDateTime(string title, DateTime publishDate);
        void Add(Post post);
        void Update(Post post);
        void Remove(Guid id);
    }
}
