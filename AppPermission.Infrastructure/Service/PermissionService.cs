using AppPermission.Domain.Entities;
using AppPermission.Domain.Interface;
using AppPermission.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Service
{
    public class PermissionService : BaseService<Permission>
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository, TransitionService transitionService) 
            : base(permissionRepository, transitionService)
        {
            _permissionRepository = permissionRepository;
        }

        public List<PermissionModel> GetPermissions()
        {
            var permissions = _permissionRepository.GetPermission();

            return permissions;
        }

        public Task<PermissionModel> GetPermissionId(int id)
        {
            var permissions = _permissionRepository.GetPermissionById(id);
            return permissions;
        }

        public async Task Save(Permission permission)
        {
            await base.Save(permission);
        }

        public async Task Update(Permission permission)
        {
            Permission permissionToUpdate = await _permissionRepository.GetId(permission.PermissionId);

            permissionToUpdate.FirstName = permission.FirstName;
            permissionToUpdate.LastName = permission.LastName;
            permissionToUpdate.PermissionType = permission.PermissionType;
            permissionToUpdate.PermissionDate = permission.PermissionDate;

            await base.Update(permissionToUpdate);
        }
        
        public async Task Remove(int id)
        {
            Permission permissionToDelete = await _permissionRepository.GetId(id);

            permissionToDelete.Deleted = true;
            permissionToDelete.DeletedDate = DateTime.Now;

            await base.Remove(permissionToDelete);
        }
    }
}
