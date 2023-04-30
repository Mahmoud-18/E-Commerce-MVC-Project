namespace ECommerceMVC.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? UpdatedOnUtc { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    //Navigation Properties
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
