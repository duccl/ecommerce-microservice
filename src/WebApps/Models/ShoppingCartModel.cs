using System.Collections.Generic;
using System.Linq;

namespace AspnetRunBasics.Models
{
    public class ShoppingCartModel
    {
        public string UserName { get; set; }
        public IEnumerable<ShoppingCartItemModel> Items { get; set; } = new List<ShoppingCartItemModel>();
        public decimal TotalPrice {
            get {
                return Items.Sum(item => item.TotalPrice);
            }
        }
    }
}
