using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel userName);
        Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel);
    }
}
