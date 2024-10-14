using AppPermission.Domain.Entities;
using AppPermission.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Service
{
    public class PermissionTypeService : BaseService<PermissionType>
    {
        private readonly IPermissionTypeRepository _repository;

        public PermissionTypeService(IPermissionTypeRepository repository, TransitionService transitionService)
            : base(repository, transitionService)
        {
            _repository = repository;
        }

        public List<PermissionType> GetPermissionType()
        {
            var permissionType = _repository.GetPermissionType();

            return permissionType;
        }

        public async Task Save(PermissionType permissionType)
        {
            await base.Save(permissionType);
        }
        public async Task Update(PermissionType permissionType)
        {
            PermissionType permissionTypeToUpdate = await _repository.GetId(permissionType.PermissionTypeId);

            permissionTypeToUpdate.Description = permissionType.Description;

            await base.Update(permissionType);
        }
        public async Task Remove(PermissionType permissionType)
        {
            PermissionType permissionTypeToUpdate = await _repository.GetId(permissionType.PermissionTypeId);

            permissionTypeToUpdate.Deleted = true;
            permissionTypeToUpdate.DeletedDate = DateTime.Now;

            await base.Remove(permissionType);
        }
    }
}
