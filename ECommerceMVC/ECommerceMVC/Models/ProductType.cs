namespace ECommerceMVC.Models;

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? CreatedOnUtc { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? UpdatedOnUtc { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    //Navigation Properties
    public ICollection<ProductTypeAttribute>? ProductTypeAttributes { get; set; } = new List<ProductTypeAttribute>();
    public ICollection<Product>? ProductItem { get; set; } = new List<Product>();

}
