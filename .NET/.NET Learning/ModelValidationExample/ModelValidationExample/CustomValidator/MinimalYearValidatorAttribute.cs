using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidator
{
    public class MinimalYearValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {

                if (date.Year < 2000)
                {
                    return new ValidationResult("Minimum year allowed is 2000");
                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
