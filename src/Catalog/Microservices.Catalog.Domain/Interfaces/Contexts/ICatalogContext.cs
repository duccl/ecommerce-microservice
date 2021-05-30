using Microservices.Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Microservices.Catalog.Domain.Interfaces.Contexts
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
