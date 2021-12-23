using Microservices.Ordering.Application.Models;

namespace Microservices.Ordering.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
