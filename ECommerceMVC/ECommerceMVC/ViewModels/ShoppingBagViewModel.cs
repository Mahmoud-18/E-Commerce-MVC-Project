using ECommerceMVC.Models;

namespace ECommerceMVC.ViewModels
{
    public class ShoppingBagViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<ShoppingBagItem> Items { get; set; }
        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal DiscountPercentage { get; set; } = 0;
        public decimal TotalPriceAfterDiscount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
