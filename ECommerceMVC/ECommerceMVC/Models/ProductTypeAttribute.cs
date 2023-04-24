using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ProductTypeAttribute
{
    public int Id { get; set; }

    [ForeignKey("ProductType")]
    public int ProductTypeId { get; set; }

    [ForeignKey("ProductAttribute")]
    public int ProductAttributeId { get; set; }

    //Navigation Properties
    public ProductType? ProductType { get; set; }
    public ProductAttribute? ProductAttribute { get; set; }
}
