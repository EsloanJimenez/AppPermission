using AppPermission.Domain.DTO;
using AppPermission.Domain.Entities;
using AutoMapper;

namespace AppPermission.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Permission, PermissionDTO>();
            CreateMap<PermissionDTO, Permission>();
        }
    }
}
