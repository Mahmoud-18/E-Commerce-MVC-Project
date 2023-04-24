using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceMVC.Models;

public class ProductAttribute
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    //Navigation Properties
    public ICollection<ProductTypeAttribute>? ProductTypeAttributes { get; set; } = new List<ProductTypeAttribute>();
    public ICollection<AttributeValues>? AttributeValues { get; set; } = new List<AttributeValues>();

}
