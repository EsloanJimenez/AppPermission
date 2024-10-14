using System;

namespace AppPermission.Domain.DTO
{
    public class PermissionDTO
    {
        public int PermissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
