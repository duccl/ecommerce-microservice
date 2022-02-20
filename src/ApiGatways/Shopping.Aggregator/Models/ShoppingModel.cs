namespace Shopping.Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public BasketModel Basket { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
