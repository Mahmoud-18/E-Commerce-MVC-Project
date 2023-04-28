using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ShoppingBagItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("ProductItem")]
    public int ProductItemId { get; set; }

    [ForeignKey("ShoppingBag")]
    public int ShoppingBagId { get; set; }

    //Navigation Properties
    public ProductItem? ProductItem { get; set; }
    public ShoppingBagItem? ShoppingBag { get; set; }
}
