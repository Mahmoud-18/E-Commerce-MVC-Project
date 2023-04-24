using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class OrderItems
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    [ForeignKey("ProductItem")]
    public int ProductItemId { get; set; }

    [ForeignKey("OrderDetails")]
    public int OrderDetailsId { get; set; }


    //Navigation Properties
    public ProductItem? ProductItem { get; set; }
    public OrderDetails? Order { get; set; }
}
