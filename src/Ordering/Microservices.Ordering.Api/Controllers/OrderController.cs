using MediatR;
using Microservices.Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Microservices.Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Microservices.Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Microservices.Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Microservices.Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetOrderByUserName")]
        [ProducesResponseType(typeof(IEnumerable<OrderVm>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUserName(string username)
        {
            var query = new GetOrdersListQuery(username);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }


        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckoutOrder([FromBody]CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}",Name = "DeleteOrder")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id});
            return NoContent();
        }
    }
}
