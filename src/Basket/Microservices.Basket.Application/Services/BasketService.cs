using Microservices.Basket.Domain.Entities;
using Microservices.Basket.Domain.Interfaces.Repositories;
using Microservices.Basket.Domain.Interfaces.Services;
using Microservices.Discount.Grpc.Protos;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        #region .: Properties :.

        private readonly IBasketRepository _basketRepository;
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountClient;

        #endregion

        #region .: Constructor :.

        public BasketService(
                IBasketRepository basketRepository, 
                DiscountProtoService.DiscountProtoServiceClient discountClient)
        {
            _basketRepository = basketRepository;
            _discountClient = discountClient;
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
            foreach (var item in basket.Items)
            {
                var discount_request = new GetDiscountRequest { ProductName = item.ProductName };
                var discount = _discountClient.GetDiscount(discount_request);
                item.Price -= decimal.Parse(discount.Amount.ToString());
            }
            return await _basketRepository.UpdateBasketAsync(basket);
        }

        #endregion
    }
}
