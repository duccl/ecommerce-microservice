namespace Microservices.Ordering.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public string CreatedBy { get; set; } = Environment.UserName;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = Environment.UserName;
        public DateTime? LastModifiedDate { get; set; }
    }
}
