using System;

namespace catalogs.api.Settings
{
    public class CatalogDatabaseSettings: ICatalogDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public CatalogDatabaseSettings()
        {
            CollectionName = Environment.GetEnvironmentVariable("COLLECTIONNAME");
            ConnectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            DatabaseName = Environment.GetEnvironmentVariable("DATABASENAME");
        }
    }
}
