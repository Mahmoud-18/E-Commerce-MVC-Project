using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    [DisplayName("Created At Utc")]
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
    public bool IsDeleted { get; set; } = false;


    [DisplayName("Parent Category")]
    [ForeignKey("Category")]
    public int? ParentCategoryId { get; set; }

    [DisplayName("Parent Category")]
    public Category? ParentCategory { get; set; }
    public ICollection<Category>? ChildsCategory { get; set; } = new List<Category>();

    //Navigation Properties
    [DisplayName("Product Categories")]
    public ICollection<ProductCategory>? ProductCategories { get; set; } = new List<ProductCategory>();
    

}
