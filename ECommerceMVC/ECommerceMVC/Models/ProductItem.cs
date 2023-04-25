using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ProductItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SKU { get; set; }
    public int StockQuantity { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [ForeignKey("Brand")]
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
    public bool IsDeleted { get; set; } = false;

    [ForeignKey("ProductType")]
    public int ProductTypeId { get; set; }

    //Navigation Properties
    public Product? Product { get; set; }
    public Brand? Brand { get; set; }
    public ProductType? ProductType { get; set; }
    public ICollection<ProductAttributeValues>? ProductAttributeValues { get; set; } = new List<ProductAttributeValues>();
    public ICollection<ShoppingBagItem>? ShoppingBagItem { get; set; } = new List<ShoppingBagItem>();
    public ICollection<OrderItems>? OrderItems { get; set; } = new List<OrderItems>();
    public ICollection<ProductImages>? ProductImages { get; set; } = new List<ProductImages>();


}
