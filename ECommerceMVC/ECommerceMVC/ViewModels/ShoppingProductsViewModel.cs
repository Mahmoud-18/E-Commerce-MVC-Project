using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class ShoppingProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal PriceBeforeDisc { get; set; }
        public decimal PriceAfterDisc { get; set; }
        public int ReviewCount { get; set; }
        public float AverageRating { get; set;}
    }
}
