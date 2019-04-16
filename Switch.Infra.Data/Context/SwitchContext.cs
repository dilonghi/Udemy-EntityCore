using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Switch.Domain.Entities;
using Switch.Infra.Data.Mappings;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment _env;

        public SwitchContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<RelationshipStatus> RelationshipStatus { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Identification> Identification { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitution { get; set; }
        public DbSet<SearchFor> SearchFor { get; set; }
        public DbSet<WorkCompany> WorkCompany { get; set; }
        public DbSet<Friend> Friend { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = EntityConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private ModelBuilder EntityConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new RelationshipStatusMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new IdentificationMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new EducationalInstitutionMap());
            modelBuilder.ApplyConfiguration(new SearchForMap());
            modelBuilder.ApplyConfiguration(new WorkCompanyMap());
            modelBuilder.ApplyConfiguration(new FriendMap());
            modelBuilder.ApplyConfiguration(new UserGroupMap());

            return modelBuilder;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseLazyLoadingProxies(false);
        }

    }
}
