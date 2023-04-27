using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, ErrorMessage = "Name must be between 2 and 50 characters.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must only contain letters and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        [StringLength(100, ErrorMessage = "Subject must be between 2 and 100 characters.", MinimumLength = 2)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        [StringLength(5000, ErrorMessage = "Message must be between 10 and 5000 characters.", MinimumLength = 10)]
        public string Message { get; set; }
    }
}
