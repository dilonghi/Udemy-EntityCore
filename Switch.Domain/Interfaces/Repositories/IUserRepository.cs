using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetById(Guid id);
        void Add(User user);
        void Update(User user);
    }
}
