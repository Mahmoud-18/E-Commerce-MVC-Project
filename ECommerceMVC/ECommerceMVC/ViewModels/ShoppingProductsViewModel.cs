namespace ECommerceMVC.ViewModels
{
    public class ShoppingProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal PriceBeforeDisc { get; set; }
        public decimal PriceAfterDisc { get; set; }
    }
}
