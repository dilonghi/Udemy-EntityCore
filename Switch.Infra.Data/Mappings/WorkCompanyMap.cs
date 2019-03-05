using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class WorkCompanyMap : IEntityTypeConfiguration<WorkCompany>
    {
        public void Configure(EntityTypeBuilder<WorkCompany> builder)
        {
            builder.ToTable("WorkCompanies");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(120)").IsRequired();
            builder.Property(x => x.AdmissionDate);
            builder.Property(x => x.OutDate);
            builder.Property(x => x.CurrentJob);

        }
    }
}
