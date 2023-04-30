using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.Validations
{
    public class ImageInputValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            List<string> images = (List<string>)value;//(List<string>)validationContext.ObjectInstance;
            int count = images.Count;
            if (count==1 && images[0] ==null)
            {
                return new ValidationResult("Select at least one image");
            }
            else
            {
                return ValidationResult.Success;
            }
            return base.IsValid(value, validationContext);
        }
    }
}
