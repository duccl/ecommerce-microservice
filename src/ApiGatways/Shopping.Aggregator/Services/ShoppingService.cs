using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;

namespace Shopping.Aggregator.Services
{
    public class ShoppingService: IShoppingService
    {
        private readonly IOrderService _orderService;
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public ShoppingService(IOrderService orderService, ICatalogService catalogService, IBasketService basketService)
        {
            _orderService = orderService;
            _catalogService = catalogService;
            _basketService = basketService;
        }

        public async Task<ShoppingModel> GetShopping(string username)
        {
            var basket = await _basketService.GetBasket(username);
            await Parallel.ForEachAsync(basket.Items, async (item, token) =>
            {
                token.ThrowIfCancellationRequested();

                item.Product = await _catalogService.GetCatalog(item.ProductId);
            });

            var orders = await _orderService.GetOrdersByUserName(username);

            return new ShoppingModel
            {
                UserName = username,
                Basket = basket,
                Orders = orders
            };
        }
    }
}
