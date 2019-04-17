using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Domain.Interfaces.Repositories;
using Switch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Switch.Infra.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SwitchContext _context;
        private readonly DbSet<Post> DbSet;

        public PostRepository(SwitchContext context)
        {
            _context = context;
            DbSet = _context.Set<Post>();
        }


        public IEnumerable<Post> GetAllPostsByUserId(Guid userId)
        {
            return DbSet.Where(x => x.UserId == userId);
        }

        public IEnumerable<Post> GetAllPostsByGroupId(int groupId)
        {
            return DbSet.Where(x => x.GroupId == groupId);
        }

        public IQueryable<Post> GetAll()
        {
            var retorno = DbSet;
            return retorno;
        }

        public Post GetById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public Post GetPostByTitleAndDateTime(string title, DateTime publishDate)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Title == title 
                                    && x.PublishDate.Day == publishDate.Day && x.PublishDate.Month == publishDate.Month && x.PublishDate.Year == publishDate.Year
                                    && x.PublishDate.Hour == publishDate.Hour);
        }

        public void Add(Post post)
        {
            DbSet.Add(post);
        }

        public void Update(Post post)
        {
            var entry = _context.Entry(post);
            DbSet.Attach(post);
            entry.State = EntityState.Modified;
            
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }
}
