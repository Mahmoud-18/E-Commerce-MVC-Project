using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ShoppingBag
{
    public int Id { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }


    //Navigation Properties
    public Customer? Customer { get; set; }
    public ICollection<ShoppingBagItem>? ShoppingBagItems { get; set; } = new List<ShoppingBagItem>();
}
