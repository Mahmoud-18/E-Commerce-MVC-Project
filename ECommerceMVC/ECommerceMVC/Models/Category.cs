using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
    public bool IsDeleted { get; set; } = false;

    [ForeignKey("Category")]
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category>? ChildsCategory { get; set; } = new List<Category>();

    //Navigation Properties
    public ICollection<ProductCategory>? ProductCategories { get; set; } = new List<ProductCategory>();
    

}
