namespace Microservices.EventBus.Messages.Events.Base
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
    }
}
