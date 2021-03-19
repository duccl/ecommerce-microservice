using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using catalogs.api.Entities;
namespace basket.api.Entities
{
    public class Basket
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}