using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.ViewModels
{
    [Keyless]
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public float Price { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public int Count { get; set; }
    }
}
