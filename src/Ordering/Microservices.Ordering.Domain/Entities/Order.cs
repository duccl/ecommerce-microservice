namespace Microservices.Ordering.Domain.Entities
{
    public class Order: Common.EntityBase
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public Address Address { get; set; }
        public Payment Payment { get; set; }
    }
}
