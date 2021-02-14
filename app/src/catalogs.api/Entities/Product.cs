using System.ComponentModel.DataAnnotations;

namespace catalogs.api.Entities
{
    public class Product
    {
        public string Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0.00,double.MaxValue)]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
