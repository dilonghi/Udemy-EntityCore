using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Switch.CrossCutting;
using Switch.Domain.Entities;
using Switch.Infra.Data.Mappings;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        public IConfiguration Configuration { get; }


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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
            optionsBuilder.UseLazyLoadingProxies(false);
        }

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
    }
}
