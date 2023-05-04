using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class ProductDetailsViewModel
    {       
        public int Id { get; set; }
        public string? Name { get; set; }
        public float price { get; set; }
        public float PriceBeforeDiscount { get; set; }
        public List<string>? Image { get; set; } = new List<string>();

        //public List<string>? Size { get; set; } = new List<string>();
        //public List<string>? Color { get; set; } = new List<string>();
        public string? Description { get; set; }
        public string? BrandName { get; set; }
               
        public int ProductCount { get; set; }
        //public string  SizeId { get; set; }
        //public string ColorId { get; set; }

        //public int SUK { get; set; }
        //public DateTime CreatetAtUtc { get; set; }
        //public int StockUnits { get; set; }
        //public string? BrandImage { get; set; }

        public List<ProductAttribute>? variationswithoptions { get; set; }
        public Product? Product { get; set; }
        public List<int> AttributeValuesIds { get; set; } = new();
    }
}
