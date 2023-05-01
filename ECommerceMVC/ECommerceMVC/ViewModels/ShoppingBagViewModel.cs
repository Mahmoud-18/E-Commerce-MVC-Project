using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class ShoppingBagViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<ShoppingBagItem> Items { get; set; }
        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPriceAfterDiscount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
