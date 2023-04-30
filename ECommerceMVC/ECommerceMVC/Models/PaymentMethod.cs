namespace ECommerceMVC.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? CreatedOnUtc { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? UpdatedOnUtc { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    //Navigation Properties
    public ICollection<OrderDetails>? Orders { get; set; } = new List<OrderDetails>();
}
