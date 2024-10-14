using AppPermission.Domain.Entities;
using AppPermission.Domain.Interface;
using AppPermission.Infrastructure.Context;
using AppPermission.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Repository
{
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IPermissionTypeRepository
    {
        private readonly AppPermissionContext _context;

        public PermissionTypeRepository(AppPermissionContext context) : base(context)
        {
            _context = context;
        }
        public List<PermissionType> GetPermissionType()
        {
            var permissionType = (from pt in _context.PermissionType
                                  orderby pt.PermissionTypeId
                                  where pt.Deleted == false
                                  select new PermissionType()
                                  {
                                      PermissionTypeId = pt.PermissionTypeId,
                                      Description = pt.Description,
                                  }).ToList();

            return permissionType;
        }

        public override async Task Save(PermissionType permissionType)
        {
            await base.Save(permissionType);
        }
        public override async Task Update(PermissionType permissionType)
        {
            await base.Update(permissionType);
        }
        public override async Task Remove(PermissionType permissionType)
        {
            await base.Remove(permissionType);
        }
    }
}
