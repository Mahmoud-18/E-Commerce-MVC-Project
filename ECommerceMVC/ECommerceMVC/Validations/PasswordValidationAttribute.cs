using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ECommerceMVC.Validations
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
            {
                return true; // Let the [Required] and [StringLength] attributes handle empty or null values
            }

            var hasLowercaseLetter = password.Any(char.IsLower);
            var hasUppercaseLetter = password.Any(char.IsUpper);
            var hasNumber = password.Any(char.IsDigit);
            var hasSpecialCharacter = Regex.IsMatch(password, "[^a-zA-Z0-9]");

            return hasLowercaseLetter && hasUppercaseLetter && hasNumber && !hasSpecialCharacter;
        }
    }
}
