using ECommerceMVC.Models;
using ECommerceMVC.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class EditUserViewModel
    {
        public int UserId { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 50 characters")]
        public string UserName { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

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

        [DisplayName("Admin User")]
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public IList<Country>? Countries { get; set; }

        public IList<IdentityRole<int>>? Roles { get; set; }
    }
}
