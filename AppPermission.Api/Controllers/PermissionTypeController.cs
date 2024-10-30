using AppPermission.Domain.DTO;
using AppPermission.Infrastructure.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly PermissionTypeService _permissionTypeService;
        private readonly IMapper _mapper;
        public PermissionTypeController(PermissionTypeService permissionTypeService, IMapper mapper)
        {
            _permissionTypeService = permissionTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permissionType = _permissionTypeService.GetPermissionType();

                var permissionTypeDTO = _mapper.Map<IEnumerable<PermissionTypeDTO>>(permissionType);

                return Ok(permissionTypeDTO);
            }catch(Exception ex)
            {
                throw new ArgumentException("Ah ocurrido un problema." + ex.Message);
            }
        }
    }
}
