using System.Text.Json;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName) =>
            await _httpClient.GetFromJsonAsync<List<OrderResponseModel>>($"api/v1/Order/{userName}", 
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                }
            );
    }
}