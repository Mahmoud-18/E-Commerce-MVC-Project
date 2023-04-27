namespace ECommerceMVC.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }

    //Navigation Properties
    public ICollection<Product> ProductItems { get; set; } = new List<Product>();
}
