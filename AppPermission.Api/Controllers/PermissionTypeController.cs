using AppPermission.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly PermissionTypeService _permissionTypeService;
        public PermissionTypeController(PermissionTypeService permissionTypeService)
        {
            _permissionTypeService = permissionTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permissionType = _permissionTypeService.GetPermissionType();

                return Ok(permissionType);
            }catch(Exception ex)
            {
                throw new ArgumentException("Ah ocurrido un problema." + ex.Message);
            }
        }
    }
}
