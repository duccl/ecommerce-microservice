using AutoMapper;
using MediatR;
using Microservices.Ordering.Application.Contracts.Infraestructure;
using Microservices.Ordering.Application.Contracts.Persistence;
using Microservices.Ordering.Application.Models;
using Microservices.Ordering.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Microservices.Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _mailService;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IMapper mapper,
                                           IEmailService mailService,
                                           IOrderRepository orderRepository,
                                           ILogger<CheckoutOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _mailService = mailService;
            _orderRepository = orderRepository;
            _logger = logger;
        }


        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} created for {newOrder.UserName}");

            await SafeSendEmail(newOrder);

            return newOrder.Id;
        }

        private async Task SafeSendEmail(Order order)
        {
            var email = new Email { To = order.Address.EmailAddress, Body = $"Hello {order.UserName}, your order {order.Id} was created!", Subject = $"Congrats for {order.Id}! It was created!" };
            try
            {
                await _mailService.SendEmail(email);
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Error sending mail for {order.Id}:");
            }
        }
    }
}
