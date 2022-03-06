using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Interfaces
{
    public interface IShoppingService
    {
        Task<ShoppingModel> GetShopping(string username);
    }
}
