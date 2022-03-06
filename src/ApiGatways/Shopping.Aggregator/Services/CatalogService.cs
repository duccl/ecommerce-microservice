using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog() => await _httpClient.GetFromJsonAsync<IEnumerable<CatalogModel>>("/api/catalog");

        public async Task<CatalogModel> GetCatalog(string id) => await _httpClient.GetFromJsonAsync<CatalogModel>($"/api/catalog/{id}");

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category) =>
            await _httpClient.GetFromJsonAsync<IEnumerable<CatalogModel>>($"/api/catalog/product-by-category/{category}");
    }
}
