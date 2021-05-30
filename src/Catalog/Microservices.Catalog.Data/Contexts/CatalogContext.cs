using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.Domain.Interfaces.Contexts;
using Microservices.Settings.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Microservices.Catalog.Data.Contexts
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        private readonly ILogger<ICatalogContext> _logger;
        public CatalogContext(IOptions<MongoDatabaseOptions> mongoSettings, ILogger<ICatalogContext> logger)
        {
            _logger = logger;
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            Products = database.GetCollection<Product>(mongoSettings.Value.CollectionName);
        }
    }
}
