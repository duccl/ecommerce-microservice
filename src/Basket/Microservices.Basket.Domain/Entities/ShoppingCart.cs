using System.Collections.Generic;
using System.Linq;

namespace Microservices.Basket.Domain.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public IEnumerable<ShoppingCartItem> Items { get; set; }
        public decimal TotalPrice {
            get {
                return Items.Sum(item => item.TotalPrice);
            }
        }
    }
}
