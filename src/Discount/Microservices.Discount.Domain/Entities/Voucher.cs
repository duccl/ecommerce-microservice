namespace Microservices.Discount.Domain.Entities
{
    public class Voucher
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
