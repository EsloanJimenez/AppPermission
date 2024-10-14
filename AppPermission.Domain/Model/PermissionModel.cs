using System;

namespace AppPermission.Domain.Model
{
    public class PermissionModel
    {
        public int PermissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
