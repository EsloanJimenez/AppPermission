using AppPermission.Domain.Entities;
using AppPermission.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPermission.Domain.Interface
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        List<PermissionModel> GetPermission();
        Task<PermissionModel> GetPermissionById(int id);
    }
}
