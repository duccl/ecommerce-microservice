using System.ComponentModel.DataAnnotations;

namespace Microservices.Basket.Domain.Entities
{
    public class ShoppingCartItem
    {
        [Range(1,int.MaxValue)]
        [Required]
        public int Quantity { get; set; }

        public string Color { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Range(0.0005, double.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        public decimal TotalPrice => Quantity * Price;
    }
}