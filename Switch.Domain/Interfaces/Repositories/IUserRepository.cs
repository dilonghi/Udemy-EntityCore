using Switch.Domain.Entities;
using System;

namespace Switch.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        void Add(User user);
        void Update(User user);
    }
}
