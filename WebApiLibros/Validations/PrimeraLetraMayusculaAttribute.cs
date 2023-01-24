using System.ComponentModel.DataAnnotations; //agregar

namespace WebApiLibros.Validations
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primer letra debe ser en mayúscula!");
            }
            return ValidationResult.Success;

        }
    }
}
