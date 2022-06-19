using AutoMapper;
using Microservices.Basket.Domain.Entities;
using Microservices.Basket.Domain.Interfaces.Repositories;
using Microservices.Basket.Domain.Interfaces.Services;
using Microservices.Discount.Grpc.Protos;
using System.Threading.Tasks;
using Microservices.EventBus.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Microservices.Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        #region .: Properties :.

        private readonly IBasketRepository _basketRepository;
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountClient;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<BasketService> _logger;

        #endregion

        #region .: Constructor :.

        public BasketService(IBasketRepository basketRepository,
                             DiscountProtoService.DiscountProtoServiceClient discountClient,
                             IMapper mapper,
                             IPublishEndpoint publishEndpoint,
                             ILogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            _discountClient = discountClient;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
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

        public async Task<bool> Checkout(BasketCheckout basketCheckout)
        {
            var basket = await GetBasketAsync(basketCheckout.UserName);

            if (basket == default)
                return false;

            var basketCheckoutEvent = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            basketCheckoutEvent.TotalPrice = basket.TotalPrice;
            _logger.LogInformation("Checking out basket for client {Client} with totalPrice {TotalPrice}", basketCheckout.UserName,  basketCheckout.TotalPrice);

            await _publishEndpoint.Publish(basketCheckoutEvent);

            await DeleteBasketAsync(basketCheckout.UserName);
            return true;
        }

        #endregion
    }
}
