using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class AttributeValues
{
    public int Id { get; set; }
    [ForeignKey("ProductAttribute")]
    public int ProductAttributeId { get; set; }
    public string Value { get; set; } = string.Empty;


    //Navigation Properties
    public ProductAttribute? ProductAttribute { get; set; }
    public ICollection<ProductAttributeValues>? ProductAttributeValues { get; set; } = new List<ProductAttributeValues>();

}
