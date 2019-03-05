using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Mappings
{
    public class UserGroupMap : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroups");

            builder.HasKey(x => new { x.UserId, x.GroupId });
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.IsAdmin);


        }
    }
}
