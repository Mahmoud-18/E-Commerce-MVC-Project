using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class ProductCategory
{
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    //Navigation Properties
    public Product? Product { get; set; }
    public Category? Category { get; set; } 
}
