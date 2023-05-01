using ECommerceMVC.Models;
using ECommerceMVC.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class EditProfileViewModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        public string LastName { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }




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
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }









        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number can only contain numbers")]
        public string PhoneNumber { get; set; }
        

        [DisplayName("Data of Birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DataOfBirth { get; set; } = new DateTime(2000, 1, 1);

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

       
    }

}
