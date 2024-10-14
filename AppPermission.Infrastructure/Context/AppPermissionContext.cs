using AppPermission.Domain.Entities;
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
    }
}
