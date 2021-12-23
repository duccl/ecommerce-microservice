﻿using MediatR;

namespace Microservices.Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand: IRequest
    {
        public int Id { get; set; }
    }
}
