using AppPermission.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppPermission.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [Key]
        public int PermissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
        public virtual PermissionType permissionTypeNavegation { get; set; }
    }
}
