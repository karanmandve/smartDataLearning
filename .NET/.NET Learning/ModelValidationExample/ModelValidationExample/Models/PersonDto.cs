using ModelValidationExample.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
    public class PersonDto
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

        [MinimalYearValidatorAttribute(ErrorMessage = "Minimum year allowed is 2000")]
        public DateTime? DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"name : {PersonName}, Email : {Email}, Phone : {Phone}, Password : {Password}, ConfirmPassword : {ConfirmPassword}, Price : {Price}, Date Of Birth : {DateOfBirth}";
        }
    }
}
