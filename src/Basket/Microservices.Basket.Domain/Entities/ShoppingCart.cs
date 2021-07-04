using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microservices.Basket.Domain.Entities
{
    public class ShoppingCart
    {
        [Required]
        [MinLength(1,ErrorMessage = "UserName must be 1 lenght at least")]
        public string UserName { get; set; }
        public IEnumerable<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice {
            get {
                return Items.Sum(item => item.TotalPrice);
            }
        }
    }
}
