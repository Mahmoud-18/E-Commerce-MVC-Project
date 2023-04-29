using ECommerceMVC.Models;
using ECommerceMVC.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class RegisterViewModel
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
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must not exceed 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City must not exceed 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State must not exceed 50 characters")]
        public string State { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number can only contain numbers")]
        public string PhoneNumber { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Zip code is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Zip code can only contain numbers")]
        public string ZipCode { get; set; }

        //[DisplayName("Country Dial Code")]
        //[Required(ErrorMessage = "Country dial code is required")]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Country dial code can only contain numbers")]
        //public string country_code { get; set; }

        [DisplayName("Data of Birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DataOfBirth { get; set; } = new DateTime(2000, 1, 1);

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [DisplayName("Admin User")]
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public IList<Country>? Countries { get; set; }

        public IList<IdentityRole<int>>? Roles { get; set; }
    }
 
}
