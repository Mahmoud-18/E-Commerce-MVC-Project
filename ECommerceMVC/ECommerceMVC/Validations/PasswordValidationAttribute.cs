using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ECommerceMVC.Validations
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
            {
                return ValidationResult.Success; // Let the [Required] and [StringLength] attributes handle empty or null values
            }

            var hasLowercaseLetter = password.Any(char.IsLower);
            var hasUppercaseLetter = password.Any(char.IsUpper);
            var hasNumber = password.Any(char.IsDigit);
            var hasSpecialCharacter = Regex.IsMatch(password, "[^a-zA-Z0-9]");
            if (hasLowercaseLetter && hasUppercaseLetter && hasNumber && hasSpecialCharacter)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Password must contain at least one lowercase letter, one uppercase letter, one number, and no special characters.");

        }
    }
}
