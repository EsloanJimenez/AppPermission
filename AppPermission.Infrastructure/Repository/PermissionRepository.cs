using AppPermission.Domain.DTO;
using AppPermission.Domain.Entities;
using AppPermission.Domain.Interface;
using AppPermission.Infrastructure.Context;
using AppPermission.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Repository
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        private readonly AppPermissionContext _context;
        public PermissionRepository(AppPermissionContext context) : base(context)
        {
            _context = context;
        }

        public List<PermissionDTO> GetPermission()
        {
            var permission = (from p in _context.Permission
                              join pt in _context.PermissionType
                              on p.PermissionType equals pt.PermissionTypeId
                              orderby p.PermissionId descending
                              where p.Deleted == false
                              select new PermissionDTO()
                              {
                                  PermissionId = p.PermissionId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  Description = pt.Description,
                                  PermissionDate = p.PermissionDate
                              }).ToList();

            return permission;
        }

        public async Task<PermissionDTO> GetPermissionById(int id)
        {
            var permission = (from p in _context.Permission
                              join pt in _context.PermissionType
                              on p.PermissionType equals pt.PermissionTypeId
                              orderby p.PermissionId descending
                              where p.Deleted == false && p.PermissionId == id
                              select new PermissionDTO()
                              {
                                  PermissionId = p.PermissionId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  Description = pt.Description,
                                  PermissionDate = p.PermissionDate
                              }).FirstOrDefault();

            return permission;
        }

        public override async Task Save(Permission permission)
        {
            await base.Save(permission);
        }
        public override async Task Update(Permission permission)
        {
            await base.Update(permission);
        }
        public override async Task Remove(Permission permission)
        {
            await base.Remove(permission);
        }
    }
}
