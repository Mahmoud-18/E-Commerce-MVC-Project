using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ProductImages
{
    public int Id { get; set; }
    public string ImageURL { get; set; }

    [ForeignKey("ProductItem")]
    public int ProductItemId { get; set; }

    //Navigation Properties
    public ProductItem? ProductItem { get; set; }
}
