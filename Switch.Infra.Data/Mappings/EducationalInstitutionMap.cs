using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class EducationalInstitutionMap : IEntityTypeConfiguration<EducationalInstitution>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitution> builder)
        {
            builder.ToTable("EducationalInstitutions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.NameInstitution).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.GraduateYear);
            builder.Property(x => x.StillStudying);
        }
    }
}
