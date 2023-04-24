namespace ECommerceMVC.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    //Navigation Properties
    public ICollection<OrderDetails>? Orders { get; set; } = new List<OrderDetails>();
}
