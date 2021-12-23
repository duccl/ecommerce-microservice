using AutoMapper;
using MediatR;
using Microservices.Ordering.Application.Contracts.Persistence;
using Microservices.Ordering.Application.Exceptions;
using Microservices.Ordering.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Microservices.Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IMapper mapper,
                                           IOrderRepository orderRepository,
                                           ILogger<DeleteOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);

            if (orderToDelete == default)
                throw new NotFoundException(nameof(Order), request.Id);

            await _orderRepository.DeleteAsync(orderToDelete);
            _logger.LogInformation($"{request.Id} deleted!");

            return Unit.Value;
        }
    }
}
