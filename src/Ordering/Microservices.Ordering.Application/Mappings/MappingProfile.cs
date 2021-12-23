using AutoMapper;
using Microservices.Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Microservices.Ordering.Domain.Entities;

namespace Microservices.Ordering.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            GetOrdersListMapping();
            CheckoutOrderMapping();
            UpdateOrderMapping();
        }

        private void CheckoutOrderMapping()
        {
            CreateMap<Address, Features.Orders.Commands.CheckoutOrder.AddressCommand>().ReverseMap();
            CreateMap<Order, Features.Orders.Commands.CheckoutOrder.CheckoutOrderCommand>().ReverseMap();
            CreateMap<Payment, Features.Orders.Commands.CheckoutOrder.PaymentCommand>().ReverseMap();
        }

        public void GetOrdersListMapping()
        {
            CreateMap<Address, AddressVm>().ReverseMap();
            CreateMap<Order, OrderVm>().ReverseMap();
            CreateMap<Payment, PaymentVm>().ReverseMap();
        }

        public void UpdateOrderMapping()
        {
            CreateMap<Address, Features.Orders.Commands.UpdateOrder.AddressCommand>().ReverseMap();
            CreateMap<Order, Features.Orders.Commands.UpdateOrder.UpdateOrderCommand>().ReverseMap();
            CreateMap<Payment, Features.Orders.Commands.UpdateOrder.PaymentCommand>().ReverseMap();
        }
    }
}
