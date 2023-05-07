using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
    public class ReviewViewModel 
    {
        public int ProductId { get; set; }
        [Required]
        public int Rate { get; set; }
        public string? ReviewDescription { get; set; }
        public string Name { get; set; }

    }
}
