using catalogs.api.Data.Interfaces;
using MongoDB.Driver;
using catalogs.api.Entities;
using catalogs.api.Settings;
using Microsoft.Extensions.Logging;
namespace catalogs.api.Data
{
    public class CatalogContext: ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        private readonly ILogger<ICatalogContext> _logger;
        public CatalogContext(ICatalogDatabaseSettings databaseSettings, ILogger<ICatalogContext> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(ICatalogDatabaseSettings)} with params {databaseSettings.CollectionName} ||{databaseSettings.ConnectionString} || {databaseSettings.DatabaseName}");
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(databaseSettings.CollectionName);
        }
    }
}
