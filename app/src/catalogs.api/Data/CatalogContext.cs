using catalogs.api.Data.Interfaces;
using MongoDB.Driver;
using catalogs.api.Entities;
using catalogs.api.Settings;
namespace catalogs.api.Data
{
    public class CatalogContext: ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public CatalogContext(ICatalogDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(databaseSettings.CollectionName);
        }
    }
}
