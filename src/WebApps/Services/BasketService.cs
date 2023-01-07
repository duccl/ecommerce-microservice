using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly ICatalogService _catalogService;
        public BasketService(HttpClient httpClient, ICatalogService catalogService)
        {
            _httpClient = httpClient;
            _catalogService = catalogService;
        }

        public async Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel) =>
            await _httpClient.PostAsJsonAsync($"/basket/checkout", basketCheckoutModel);

        public async Task<BasketModel> UpdateBasket(BasketModel basketModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"/basket", basketModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return JsonSerializer.Deserialize<BasketModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            });
        }

        async Task<BasketModel> IBasketService.GetBasket(string userName)
        {
            var cart = await _httpClient.GetFromJsonAsync<BasketModel>($"/basket/{userName}");

            foreach (var item in cart.Items)
            {
                var product  = await _catalogService.GetCatalog(item.ProductId);
                item.ProductName = product.Name;
                item.ProductId = product.Id;
                item.ProductSummary = product.Summary;
                item.Image = product.Image;
                item.Price = product.Price;
            }

            return cart;
        }
    }
}
