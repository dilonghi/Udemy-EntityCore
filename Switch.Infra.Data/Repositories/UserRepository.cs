using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Domain.Interfaces.Repositories;
using Switch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Switch.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SwitchContext _context;
        private readonly DbSet<User> DbSet;

        public UserRepository(SwitchContext context)
        {
            _context = context;
            DbSet = _context.Set<User>();
        }


        public IQueryable<User> GetAll()
        {
            return DbSet;

        }
        public User GetById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Email.Address == email);
        }

        public void Add(User user)
        {
            DbSet.Add(user);
        }

        public void Update(User user)
        {
            var entry = _context.Entry(user);
            DbSet.Attach(user);
            entry.State = EntityState.Modified;
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        //public bool DocumentExists(string document)
        //{
        //    return _context.Customer.Any(x => x.Document.Number == document);
        //}

        //public GetUserCommandResult Get(string firstName)
        //{
        //    var sql = @"select * from Customers c 
        //                     left join User u on u.Id=c.Id
        //                     where u.Username = @username ";

        //    using (var conn = new SqlConnection(@"Server=sql5039.site4now.net; Database=DB_A4598C_ibsapps; User Id=DB_A4598C_ibsapps_admin;Password = dspectre32;"))
        //    {
        //        conn.Open();
        //        return conn.Query<GetUserCommandResult>(sql, new { firstName = firstName }).FirstOrDefault();
        //    }

        //    //return _context.Customer
        //    //        .Include(x=>x.User)
        //    //        .AsNoTracking()
        //    //        .Select(x => new GetCustomerCommandResult
        //    //        {
        //    //            Name = x.Name.ToString(),
        //    //            Document = x.Document.Number,
        //    //            Active = x.User.Active,
        //    //            Email = x.Email.Address,
        //    //            Username = x.User.UserName,
        //    //            Password = x.User.Password
        //    //        })
        //    //        .FirstOrDefault(x => x.Username == username);
        //}
    }
}
