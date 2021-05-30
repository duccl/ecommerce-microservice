using System.Threading.Tasks;

namespace Microservices.Basket.Domain.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<Entities.Basket> GetBasketAsync(string ownerId);
        Task<Entities.Basket> UpdateBasketAsync(string ownerId, Entities.Basket basket);
        Task<Entities.Basket> CreateBasketAsync(string ownerId);
        Task DeleteBasketAsync(string ownerId);
    }
}