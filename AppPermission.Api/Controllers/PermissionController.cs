using AppPermission.Domain.DTO;
using AppPermission.Domain.Entities;
using AppPermission.Infrastructure.Exceptions;
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
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _permissionService;
        private readonly IMapper _mapper;
        public PermissionController(PermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permission = _permissionService.GetPermissions();

                var permissionDTO = _mapper.Map<IEnumerable<PermissionType>>(permission);

                return Ok(permissionDTO);
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

                var permissionDTO = _mapper.Map<IEnumerable<PermissionType>>(permission);

                return Ok(permissionDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO is null)
                    throw new PermissionException("El permiso no puede ser nulo.");

                var permission = _mapper.Map<Permission>(permissionDTO);

                await _permissionService.Save(permission);

                return Ok(permission);
            }
            catch (Exception ex)
            {
                return BadRequest();
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
        [HttpDelete("{id}")]
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
