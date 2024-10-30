using AppPermission.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPermission.Infrastructure.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.PermissionId);

            builder.Property(e => e.PermissionId).ValueGeneratedNever();

            builder.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

            builder.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

            builder.Property(e => e.PermissionDate).HasColumnType("date");

            builder.HasOne(d => d.permissionTypeNavegation)
                  .WithMany(p => p.Permissions)
                  .HasForeignKey(e => e.PermissionTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Permissio__Permi__403A8C7D");
        }
    }
}
