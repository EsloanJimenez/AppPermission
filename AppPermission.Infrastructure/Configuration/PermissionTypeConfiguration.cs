using AppPermission.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPermission.Infrastructure.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(e => e.PermissionTypeId);

            builder.Property(e => e.PermissionTypeId);

            builder.Property(e => e.DeletedDate)
                 .IsRequired()
                 .HasMaxLength(200)
                 .IsUnicode(false);
        }
    }
}
