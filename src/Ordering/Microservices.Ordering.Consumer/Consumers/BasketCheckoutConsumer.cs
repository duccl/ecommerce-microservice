using AutoMapper;
using MassTransit;
using MediatR;
using Microservices.EventBus.Messages;
using Microservices.Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Microservices.Ordering.Consumer.Consumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMapper mapper,
                                      IMediator mediator, 
                                      ILogger<BasketCheckoutConsumer> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            _logger.LogDebug("Received message {id} created at {CreationDate}", context.Message.Id, context.Message.CreationDate);
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);
            _logger.LogInformation("Checkout made for {UserName} basket with result {result}!", context.Message.UserName, result);
        }
    }
}
