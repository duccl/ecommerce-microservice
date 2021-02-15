using catalogs.api.Entities;
using catalogs.api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalogs.api.Data.Interfaces;
using MongoDB.Driver;
namespace catalogs.api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task Create(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public Task<bool> Delete(Product product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext.Products.Find(prodcut => prodcut.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            return await _catalogContext
                            .Products
                            .Find(product => product.Category.ToLower() == category.ToLower())
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _catalogContext
                            .Products
                            .Find(product => product.Name.ToLower() == name.ToLower())
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(product => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var operationResult = await _catalogContext
                                    .Products
                                    .ReplaceOneAsync(filter: collectionProduct => collectionProduct.Id == product.Id, 
                                                     replacement: product);
            return operationResult.IsAcknowledged && operationResult.ModifiedCount > 0;
        }
    }
}
