using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(120)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar(400)").IsRequired();
            builder.Property(x => x.UrlImage).HasMaxLength(1024).IsRequired();

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Group);

        }
    }
}
