using MongoDB.Bson.Serialization.Attributes;

namespace basket.api.Entities
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Basket Basket { get; set; }
    }
}