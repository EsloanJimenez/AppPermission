using System;
using System.ComponentModel.DataAnnotations;

namespace AppPermission.Domain.DataAnota
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime date)
            {
                if (date > DateTime.Now)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("La fecha debe ser mayor que la fecha actual.");
            }

            return new ValidationResult("Formato de fecha no valido.");
        }
    }
}
