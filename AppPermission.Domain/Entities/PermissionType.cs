using AppPermission.Domain.Core;

namespace AppPermission.Domain.Entities
{
    public class PermissionType : BaseEntity
    {
        public int PermissionTypeId { get; set; }
        public string Description { get; set; }
    }
}
