﻿using AppPermission.Domain.Entities;
using AppPermission.Domain.Interface;
using AppPermission.Domain.Model;
using AppPermission.Infrastructure.Context;
using AppPermission.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Repository
{ 
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AppPermissionContext context) : base(context)
        {
        }

        public List<PermissionModel> GetPermission()
        {
            var permission = (from p in _context.Permission
                              join pt in _context.PermissionType
                              on p.PermissionTypeId equals pt.PermissionTypeId
                              orderby p.PermissionId descending
                              where p.Deleted == false
                              select new PermissionModel()
                              {
                                  PermissionId = p.PermissionId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  PermissionTypeId = pt.PermissionTypeId,
                                  Description = pt.Description,
                                  PermissionDate = p.PermissionDate
                              }).ToList();

            return permission;
        }

        public async Task<PermissionModel> GetPermissionById(int id)
        {
            var permission = (from p in _context.Permission
                              join pt in _context.PermissionType
                              on p.PermissionTypeId equals pt.PermissionTypeId
                              orderby p.PermissionId descending
                              where p.Deleted == false && p.PermissionId == id
                              select new PermissionModel()
                              {
                                  PermissionId = p.PermissionId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  Description = pt.Description,
                                  PermissionDate = p.PermissionDate
                              }).FirstOrDefault();

            return permission;
        }
    }
}
