using MongoDB.Driver;
using catalogs.api.Entities;
namespace catalogs.api.Data.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
