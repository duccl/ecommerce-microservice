using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Microservices.Catalog.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }
        [Range(0.00, double.MaxValue)]
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
