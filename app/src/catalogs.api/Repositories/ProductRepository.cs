﻿using catalogs.api.Entities;
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

        public Task Create(Product product)
        {
            throw new System.NotImplementedException();
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

        public Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(product => true).ToListAsync();
        }

        public Task<bool> Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
