namespace AspnetRunBasics.Models
{
    public class ShoppingCartItemModel
    {
        public int Quantity { get; set; }

        public string Color { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice => Quantity * Price;
    }
}