using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class SearchForMap : IEntityTypeConfiguration<SearchFor>
    {
        public void Configure(EntityTypeBuilder<SearchFor> builder)
        {
            builder.ToTable("SearchFor");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasColumnType("varchar(15)").IsRequired();

            builder.HasData(
                new SearchFor() { Id = 1, Description = "NotSpecified" },
                new SearchFor() { Id = 2, Description = "Date" },
                new SearchFor() { Id = 3, Description = "Friendship" },
                new SearchFor() { Id = 4, Description = "RelationShip" }
                );
        }
    }
}
