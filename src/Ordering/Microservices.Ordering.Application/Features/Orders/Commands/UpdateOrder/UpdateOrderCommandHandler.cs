using AutoMapper;
using MediatR;
using Microservices.Ordering.Application.Contracts.Persistence;
using Microservices.Ordering.Application.Exceptions;
using Microservices.Ordering.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Microservices.Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IMapper mapper,
                                           IOrderRepository orderRepository,
                                           ILogger<UpdateOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);

            if (orderToUpdate == default)
                throw new NotFoundException(nameof(Order), request.Id);

            _mapper.Map(request, orderToUpdate);

            await _orderRepository.UpdateAsync(orderToUpdate);

            _logger.LogInformation($"{orderToUpdate.Id} updated");

            return Unit.Value;
        }

    }
}
