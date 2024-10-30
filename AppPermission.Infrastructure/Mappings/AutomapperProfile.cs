using AppPermission.Domain.DTO;
using AppPermission.Domain.Entities;
using AppPermission.Domain.Model;
using AutoMapper;

namespace AppPermission.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            #region "PERMISSION"
            CreateMap<PermissionModel, PermissionDTO>();
            CreateMap<PermissionDTO, PermissionModel>();
            #endregion

            #region "PERMISSION TIPE"
            CreateMap<PermissionType, PermissionTypeDTO>();
            CreateMap<PermissionTypeDTO, PermissionType>();
            #endregion
        }
    }
}
