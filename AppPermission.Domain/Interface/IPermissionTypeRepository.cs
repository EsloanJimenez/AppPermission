using AppPermission.Domain.Entities;
using System.Collections.Generic;

namespace AppPermission.Domain.Interface
{
    public interface IPermissionTypeRepository : IBaseRepository<PermissionType>
    {
        List<PermissionType> GetPermissionType();
    }
}
