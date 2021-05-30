using Microservices.Catalog.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
namespace Microservices.Basket.Domain.Entities
{
    public class Basket
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}