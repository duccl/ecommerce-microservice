using Microservices.Basket.Domain.Entities;
using System.Threading.Tasks;

namespace Microservices.Basket.Domain.Interfaces.Services
{
    public interface IBasketService
    {
        Task<ShoppingCart> GetBasketAsync(string userName);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
        Task DeleteBasketAsync(string userName);
    }
}
