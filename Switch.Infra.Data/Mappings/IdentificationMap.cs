using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class IdentificationMap : IEntityTypeConfiguration<Identification>
    {
        public void Configure(EntityTypeBuilder<Identification> builder)
        {
            builder.ToTable("Identifications");

            builder.HasKey(x => x.Id);
            //builder.Property(x => x..TipoDocumento);
            builder.Property(x => x.Numero).HasColumnType("varchar(14)").IsRequired();
            
        }
    }
}
