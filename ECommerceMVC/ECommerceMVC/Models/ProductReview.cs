using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }
      
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        //Navigation Properties
        public Product? Product { get; set; }

    }
}