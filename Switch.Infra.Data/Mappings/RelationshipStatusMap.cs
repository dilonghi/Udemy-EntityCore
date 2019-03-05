using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class RelationshipStatusMap : IEntityTypeConfiguration<RelationshipStatus>
    {
        public void Configure(EntityTypeBuilder<RelationshipStatus> builder)
        {
            builder.ToTable("RelationshipStatus");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasColumnType("varchar(15)").IsRequired();

            builder.HasData(
                new RelationshipStatus() { Id = 1, Description = "NotSpecified" },
                new RelationshipStatus() { Id = 2, Description = "Single" },
                new RelationshipStatus() { Id = 3, Description = "RelationShip" },
                new RelationshipStatus() { Id = 4, Description = "Maried" }
                );
        }
    }
}
