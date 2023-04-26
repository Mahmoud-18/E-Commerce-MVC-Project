namespace ECommerceMVC.Models;

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    //Navigation Properties
    public ICollection<ProductTypeAttribute>? ProductTypeAttributes { get; set; } = new List<ProductTypeAttribute>();
    public ICollection<Product>? ProductItem { get; set; } = new List<Product>();

}
