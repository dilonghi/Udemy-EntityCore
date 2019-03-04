using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Switch.CrossCutting;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);


        }
    }
}
