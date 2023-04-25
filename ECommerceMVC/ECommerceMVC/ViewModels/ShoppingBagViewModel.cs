using ECommerceMVC.Models;

namespace ECommerceMVC.ViewModels
{
    public class ShoppingBagViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<ShoppingBagItem> Items { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

    }
}
