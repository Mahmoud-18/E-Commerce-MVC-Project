using ECommerceMVC.Validations;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
    public class AddProductViewModel
    {
        [Microsoft.Build.Framework.Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        //
        [Microsoft.Build.Framework.Required]
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        //
        [Microsoft.Build.Framework.Required]
        [DisplayName("Brand Name")]
        public int BrandId { get; set; }
        //
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000000, ErrorMessage = "The Price Shold be Positive Value and less than 1,000,000")]
        public float Price { get; set; }
        //
        [Microsoft.Build.Framework.Required]
        [ImageInputValidation]
        public List<string> Images { get; set; } = new List<string>();
        //
        public List<ProductAttributeViewModel> ProductAttribute { get; set; } = new List<ProductAttributeViewModel>();
        //
        [Microsoft.Build.Framework.Required]
        public string Description { get; set; }
        //
        [Microsoft.Build.Framework.Required]
        [DisplayName("Stock Units")]
        [Range(0, 1000000, ErrorMessage = "The Stock Units Shold be Positive Value and less than 1,000,000")]
        public int StockUnits { get; set; }
        //
        [DisplayName("Discount")]
        public int DiscountId { get; set; }
        //
        //[DisplayName("Discount Name")]
        //public string DiscountName { get; set; }

    }
}
