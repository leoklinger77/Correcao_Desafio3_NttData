using System;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Extensions.DataAnnotation.Supplier
{
    public class TodayCanNotAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value != null)
            {
                DateTime date = DateTime.Parse(value.ToString());
                if (date.Date == DateTime.Now.Date) return new ValidationResult("Data não pode ser igual Hoje");
            }
            return ValidationResult.Success;
        }
    }
}
