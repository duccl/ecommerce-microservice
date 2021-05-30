using MongoDB.Driver;
using Microservices.Catalog.Domain.Entities;

namespace Microservices.Catalog.Domain.Interfaces.Contexts
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
