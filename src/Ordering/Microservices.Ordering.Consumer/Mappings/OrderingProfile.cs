using AutoMapper;

namespace Microservices.Ordering.Consumer.Mappings
{
    public class OrderingProfile: Profile
    {
        public OrderingProfile()
        {
            CreateMap <Application.Features.Orders.Commands.CheckoutOrder.CheckoutOrderCommand, EventBus.Messages.BasketCheckoutEvent>().ReverseMap();
            CreateMap <Application.Features.Orders.Commands.CheckoutOrder.AddressCommand, EventBus.Messages.Address>().ReverseMap();
            CreateMap <Application.Features.Orders.Commands.CheckoutOrder.PaymentCommand, EventBus.Messages.Payment>().ReverseMap();
        }
    }
}
