using MongoDB.Driver;
using Microsoft.Extensions.Logging;
using Microservices.Catalog.Domain.Interfaces.Contexts;
using Microservices.Catalog.Domain.Entities;

namespace Microservices.Catalog.Data.Contexts
{
    public class CatalogContext: ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        private readonly ILogger<ICatalogContext> _logger;
        public CatalogContext(ILogger<ICatalogContext> logger)
        {
            _logger = logger;
        }
    }
}
