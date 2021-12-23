using AutoMapper;
using MediatR;
using Microservices.Ordering.Application.Contracts.Persistence;

namespace Microservices.Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    internal class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, IEnumerable<OrderVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<OrderVm>>(await _orderRepository.GetOrdersByUserName(request.Username));
    }
}
