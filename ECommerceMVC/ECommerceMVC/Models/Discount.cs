namespace ECommerceMVC.Models;

public class Discount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActice { get; set; }

    //Navigation Properties

    public ICollection<Product>? Products { get; set;} = new List<Product>();

}
