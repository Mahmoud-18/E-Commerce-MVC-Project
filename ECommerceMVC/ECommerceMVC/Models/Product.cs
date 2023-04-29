using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; } = 0;
    public DateTime CreatedAtUtc { get; set;}
    public DateTime? UpdatedAtUtc { get;set;}
    public DateTime? DeletedAtUtc { get; set; }
    public bool IsDeleted { get; set; } = false;

    [ForeignKey("Discount")]
    public int? DiscountId { get; set; }

    [ForeignKey("ProductType")]
    public int? ProductTypeId { get; set; }

    [ForeignKey("Brand")]
    public int BrandId { get; set; }

    //Navigation Properties
    public Discount? Discount { get; set; }
    public Brand? Brand { get; set; }
    public ProductType? ProductType { get; set; }
    public ICollection<ProductItem>? Items { get; set; } = new List<ProductItem>();
    public ICollection<ProductCategory>? ProductCategories { get; set; } = new List<ProductCategory>();
}
