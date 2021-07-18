using Microservices.Basket.Domain.Entities;
using Microservices.Basket.Domain.Interfaces.Repositories;
using Microservices.Basket.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Microservices.Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        #region .: Properties :.

        private readonly IBasketRepository _basketRepository;

        #endregion

        #region .: Constructor :.

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        #endregion

        #region .: IBasketService Methods Implementation :.

        public async Task DeleteBasketAsync(string userName)
        {
            await _basketRepository.DeleteBasketAsync(userName);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName)
        {
            return await _basketRepository.GetBasketAsync(userName);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            return await _basketRepository.UpdateBasketAsync(basket);
        }

        #endregion
    }
}
