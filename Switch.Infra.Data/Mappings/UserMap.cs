using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Birthdate).IsRequired();
            builder.Property(x => x.Email.Address)
                .HasColumnName("Email")
                .HasColumnType("varchar(160)")
                .IsRequired();

            builder.Property(x => x.Name.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(x => x.Name.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(x => x.Password).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.Sexo).IsRequired();
            builder.Property(x => x.Mobile).HasColumnType("varchar(35)");

            builder.HasOne(x => x.Identification)
                .WithOne(x => x.User)
                .HasForeignKey<Identification>(x => x.UserId);

            builder.HasMany(x => x.Posts).WithOne(x => x.User);
            builder.HasMany(x => x.WorkCompanies).WithOne(x => x.User);
            builder.HasMany(x => x.EducationalInstitutions).WithOne(x => x.User);
            builder.HasMany(x => x.Friends).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict); 
            builder.HasMany(x => x.Comments).WithOne(x => x.User);
            builder.HasMany(x => x.UserGroups).WithOne(x => x.User);

            builder.HasOne(u => u.RelationshipStatus);
            builder.HasOne(u => u.SearchFor);
        }
    }
}
