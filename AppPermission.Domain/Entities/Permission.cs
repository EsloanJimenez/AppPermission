using AppPermission.Domain.Core;
using AppPermission.Domain.DataAnota;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppPermission.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [Key]
        public int PermissionId { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El campo nombre solo admite 50 caracteres")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El campo apellido solo admite 50 caracteres")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo tipo de permiso es requerido.")]
        public int PermissionType { get; set; }
        [FutureDate(ErrorMessage = "La fecha debe ser mayor que la fecha actual.")]
        public DateTime PermissionDate { get; set; }
    }
}
