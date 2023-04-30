using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace ECommerceMVC.ViewModels
{
    public class ProductAttributeViewModel
    {
        [Required]
        public string ColorAttributeValueID { get; set; }
        [Required]
        //[RegularExpression("[A-Z]",ErrorMessage ="Capital Cases ONLY")]
        public string SizeAttributeValueID { get; set; }
        [Required]
        [Range(0,1000,ErrorMessage ="Range Between (0,1000)")]
        public int CountAttributeValue { get; set; } 
    }
}
