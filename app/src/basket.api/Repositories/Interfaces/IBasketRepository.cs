using System.Threading.Tasks;
using basket.api.Entities;

namespace basket.api.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(string ownerId);
        Task<Basket> UpdateBasketAsync(string ownerId,Basket basket);
        Task<Basket> CreateBasketAsync(string ownerId);
        Task DeleteBasketAsync(string ownerId);
    }
}