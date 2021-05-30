namespace Microservices.Settings.Options
{
    public class MongoDatabaseOptions
    {
        public const string MongoDatabaseSection = "MongoSettings";
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
