using AppPermission.Domain.DTO;
using AppPermission.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPermission.Domain.Interface
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        List<PermissionDTO> GetPermission();
        Task<PermissionDTO> GetPermissionById(int id);
    }
}
