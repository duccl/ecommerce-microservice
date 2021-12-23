using MediatR;
using Microsoft.Extensions.Logging;

namespace Microservices.Ordering.Application.Behaviours
{
    public class UnhandledBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Unhandled Error processing request {typeof(TRequest).Name} {request}");
                throw;
            }
        }
    }
}
