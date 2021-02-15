using System.Collections.Generic;
using System.Threading.Tasks;
using catalogs.api.Entities;
namespace catalogs.api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string category);
        Task<Product> GetProduct(string id);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);

    }
}
