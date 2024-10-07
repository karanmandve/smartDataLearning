using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidator
{
    public class MinimalYearValidatorAttribute : ValidationAttribute
    {

        public int MinimumYear { get; set; }
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";

        public MinimalYearValidatorAttribute()
        {
        }

        public MinimalYearValidatorAttribute(int minimalYear)
        {
            MinimumYear = minimalYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;

                if (date.Year >= MinimumYear)
                {

                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                    //return new ValidationResult("Minimum year allowed is 2000");
                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
