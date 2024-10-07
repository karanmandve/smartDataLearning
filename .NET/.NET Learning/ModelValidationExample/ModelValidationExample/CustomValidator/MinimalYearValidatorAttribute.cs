using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace ModelValidationExample.CustomValidator
{
    public class MinimalYearValidatorAttribute : ValidationAttribute
    {

        public int MinimumYear { get; set; } = 2000;
        public MinimalYearValidatorAttribute()
        {
        }

        public MinimalYearValidatorAttribute(int minimumYear)
        {
                MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value != null)
            {
                var date = (DateTime)value;

                if (date.Year >= MinimumYear)
                {

                    return new ValidationResult(ErrorMessage);
                    //return new ValidationResult("Minimum year allowed is 2000");
                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
