using Microservices.Discount.Domain.Entities;
using Microservices.Discount.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Discount.Api.Controllers
{
    [Route("api/discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        #region .: Properties :.

        private readonly IDiscountRepository _repository;

        #endregion

        #region .: Constructor :.

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region .: Methods :.


        [HttpGet("{productName}",Name = "GetDiscount")]
        [ProducesResponseType(typeof(Voucher), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Voucher>> Get(string productName)
        {
            return Ok(await _repository.GetVoucher(productName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Voucher), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Voucher>> Post([FromBody] Voucher voucher)
        {
            await _repository.CreateVoucher(voucher);
            return CreatedAtRoute("GetDiscount", new { productName = voucher.ProductName }, voucher);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Put([FromBody] Voucher voucher)
        {
            return Ok(await _repository.UpdateVoucher(voucher));
        }

        [HttpDelete("{productName}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(string productName)
        {
            return Ok(await _repository.DeleteVoucher(productName));
        }

        #endregion
    }
}
