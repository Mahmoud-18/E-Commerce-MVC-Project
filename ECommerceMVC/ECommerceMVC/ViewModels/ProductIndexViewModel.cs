namespace ECommerceMVC.ViewModels
{
    public class ProductIndexViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public float Price { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public int Count { get; set; }
    }
}
