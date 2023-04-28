namespace ECommerceMVC.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string? Name { get; set; }
        public float price { get; set; }
        public List<string>? Image { get; set; }
        public string? Description { get; set; }
        public DateTime CreatetAtUtc { get; set; }
        public int SUK { get; set; }
        public int StockUnits { get; set; }
        public string? BrandName { get; set; }
        public string? BrandImage { get; set; }
    }
}
