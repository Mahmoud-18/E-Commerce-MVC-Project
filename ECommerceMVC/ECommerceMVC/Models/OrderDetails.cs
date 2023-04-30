using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class OrderDetails
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderTotalPrice { get; set; }
    public decimal ShippingPrice { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public bool IsDeleted { get; set; } = false;

    public bool IsCanceled { get; set; }= false; 

    public DateTime? DeletedOnUtc { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [ForeignKey("Address")]
    public int ShippingAddressId { get; set; }

    [ForeignKey("PaymentMethod")]
    public int PaymentMethodId { get; set; }

    [ForeignKey("OrderStatus")]
    public int OrderStatusId { get; set; }

    //Navigation Properties
    public ICollection<OrderItems>? OrderItems { get; set; } = new List<OrderItems>();
    public OrderStatus? OrderStatus { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public Customer? Customer { get; set; }
    public Address? Address { get; set; }

}
