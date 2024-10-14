using AppPermission.Domain.Entities;
using AppPermission.Infrastructure.Exceptions;
using AppPermission.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _permissionService;
        public PermissionController(PermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permission = _permissionService.GetPermissions();
                return Ok(permission);
            }catch(Exception ex)
            {
                throw new ArgumentException($"mensaje de error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var permission = _permissionService.GetPermissionId(id);
                return Ok(permission);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Permission permission)
        {
            try
            {
                if (permission is null)
                    throw new PermissionException("El permiso no puede ser nulo.");

                //permission.PermissionDate = DateTime.Now;

                await _permissionService.Save(permission);

                return Ok(permission);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Permission permission)
        {
            try
            {
                if (permission is null)
                    throw new PermissionException("El permiso no puede ser nulo.");

                await _permissionService.Update(permission);
                return Ok(permission);
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var permission = await _permissionService.GetPermissionId(id);

                if (permission is null)
                    throw new PermissionException("Los permisos estan nulos.");

                await _permissionService.Remove(id);

                return NoContent();
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
