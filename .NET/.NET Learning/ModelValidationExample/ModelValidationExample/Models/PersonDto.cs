using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationExample.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
    public class PersonDto : IValidatableObject
    {
        [Required(ErrorMessage = "Person name can't be empty or null")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Person name should be between {2} and {1}")]
        public string? PersonName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email not in correct format")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Phone number is not in correct format")]
        public string? Phone { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password is not match")]
        public string? ConfirmPassword { get; set; }
        public double? Price { get; set; }


        //[MinimalYearValidatorAttribute(2005, ErrorMessage = "Minimum year allowed is 2000")]
        [MinimalYearValidatorAttribute(2005, ErrorMessage = "Minimum year allowed is {0}")]
        //[MinimalYearValidatorAttribute(2005)]
        //[BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidatorAttribute("FromDate", ErrorMessage = "'From Date' should be older or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return $"name : {PersonName}, Email : {Email}, Phone : {Phone}, Password : {Password}, ConfirmPassword : {ConfirmPassword}, Price : {Price}, Date Of Birth : {DateOfBirth}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either date of birth or age is supplied.");
            }
        }
    }
}
