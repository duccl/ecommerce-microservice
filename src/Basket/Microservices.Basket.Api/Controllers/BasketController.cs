using Microservices.Basket.Domain.Entities;
using Microservices.Basket.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Microservices.Basket.Api.Controllers
{
    [ApiController]
    [Route("api/basket")]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK,Type= typeof(ShoppingCart))]
        public async Task<IActionResult> GetBasketAsync(string userName)
        {
            return Ok(await _basketService.GetBasketAsync(userName));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCart))]
        public async Task<IActionResult> UpdateBasketAsync(ShoppingCart basket)
        {
            return Ok(await _basketService.UpdateBasketAsync(basket));
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasketAsync(string userName)
        {
            await _basketService.DeleteBasketAsync(userName);
            return Ok();
        }

        [HttpPost("checkout")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            var checkoutSuccessfull = await _basketService.Checkout(basketCheckout);

            if (checkoutSuccessfull)
                return Ok();

            return BadRequest();
        }
    }
}
