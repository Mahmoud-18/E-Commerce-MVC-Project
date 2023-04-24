using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ProductAttributeValues
{
    public int Id { get; set; }

    [ForeignKey("AttributeValues")]
    public int AttributeValuesId { get; set; }

    [ForeignKey("ProductItem")]
    public int ProductItemId { get; set; }

    //Navigation Properties
    public ProductItem? ProductItem { get; set; }
    public AttributeValues? AttributeValues { get; set; } 

}
