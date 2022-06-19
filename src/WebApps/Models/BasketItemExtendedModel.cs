namespace AspnetRunBasics.Models
{
    public class BasketItemExtendedModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSummary { get; set; }
        public string Image { get; internal set; }
    }
}