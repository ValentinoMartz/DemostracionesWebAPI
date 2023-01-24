using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibros.Validations
{
    public class FechaDeNacimientoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value).Year > 1950)
            {
                return ValidationResult.Success;

            }

            return new ValidationResult("La fecha debe ser mayor al año 1950");

        }
    }
}
