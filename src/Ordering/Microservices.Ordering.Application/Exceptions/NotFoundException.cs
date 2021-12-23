namespace Microservices.Ordering.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() { }
        public NotFoundException(string name, object key) : base($"Entity '{name}' ({key}) was not found") { }
        public NotFoundException(string name, object key, Exception inner) : base($"Entity '{name}' ({key}) was not found", inner) { }
        protected NotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
