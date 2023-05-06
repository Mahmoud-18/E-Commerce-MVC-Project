using ECommerceMVC.Models;

namespace ECommerceMVC.ViewModels
{
    public class CheckOutViewModel
    {
        public int Id { get; set; }
        public Address ShippingAddress { get; set; }
        public Customer Customer { get; set; }        
        public List<ShoppingBagItem> Items { get; set; }
        public int PaymentMethodId { get; set; }
        public List<PaymentMethod> PaymentMethod { get; set; }
        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal TotalDiscount { get; set; }       
        public decimal TotalPriceAfterDiscount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal OrderTotalPrice { get; set; }       
    }
}
