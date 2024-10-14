using AppPermission.Domain.Core;
using System;

namespace AppPermission.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public int PermissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
