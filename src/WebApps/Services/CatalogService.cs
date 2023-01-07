using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog() => 
            await _httpClient.GetFromJsonAsync<IEnumerable<CatalogModel>>("/catalog");

        public async Task<CatalogModel> GetCatalog(string id) => 
            await _httpClient.GetFromJsonAsync<CatalogModel>($"/catalog/{id}");

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category) =>
            await _httpClient.GetFromJsonAsync<IEnumerable<CatalogModel>>($"/catalog/product-by-category/{category}");
    }
}
