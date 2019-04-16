using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Switch.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IQueryable<User> GetAll();
        User GetById(Guid id);
        User GetByEmail(string email);
        void Add(User user);
        void Update(User user);
        void Remove(Guid id);
    }
}
