using System.Collections.Generic;

namespace AspnetRunBasics.Models
{
    public class BasketModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<BasketItemExtendedModel> Items { get; set; }
    }
}
