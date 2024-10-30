using AppPermission.Domain.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppPermission.Domain.Entities
{
    public class PermissionType : BaseEntity
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permission>();
        }
        [Key]
        public int PermissionTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
