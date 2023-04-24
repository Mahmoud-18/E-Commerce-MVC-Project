namespace ECommerceMVC.Models;

public class OrderStatus
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;

    //Navigation Properties
    public ICollection<OrderDetails>? Orders { get; set; } = new List<OrderDetails>();

}
