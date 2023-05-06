using ECommerceMVC.Models;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }        
        public string PaymentMethod { get; set; }        
        public string OrderStatus { get; set; }      
        public Address ShippingAddress { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal DiscountPercentage { get; set; } = 0;
        public decimal TotalPriceAfterDiscount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal OrderTotalPrice { get; set; }        
        public bool IsCanceled { get; set; } = false;     
        public int ShippingAddressId { get; set; }           
        public int OrderStatusId { get; set; }
    }
}
