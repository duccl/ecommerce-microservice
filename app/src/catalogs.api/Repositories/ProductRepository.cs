using catalogs.api.Entities;
using catalogs.api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalogs.api.Data.Interfaces;

namespace catalogs.api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public Task Create(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetProduct(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
