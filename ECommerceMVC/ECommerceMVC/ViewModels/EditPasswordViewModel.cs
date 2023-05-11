using ECommerceMVC.Validations;
using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
    public class EditPasswordViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [PasswordValidation(ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and no special characters.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [PasswordValidation(ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and no special characters.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password is required")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}