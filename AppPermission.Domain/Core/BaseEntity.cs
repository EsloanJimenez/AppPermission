using System;

namespace AppPermission.Domain.Core
{
    public class BaseEntity
    {
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
