using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;

namespace AspnetRunBasics.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<IEnumerable<BasketCheckoutModel>> IOrderService.GetOrdersByUserName(string userName) =>
            await _httpClient.GetFromJsonAsync<List<BasketCheckoutModel>>($"/order/{userName}",
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                }
            );
    }
}