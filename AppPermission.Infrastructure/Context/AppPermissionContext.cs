using AppPermission.Domain.Entities;
using AppPermission.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppPermission.Infrastructure.Context
{
    public class AppPermissionContext : DbContext
    {
        public AppPermissionContext(DbContextOptions<AppPermissionContext> op) : base(op)
        {
            
        }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
        }
    }
}
