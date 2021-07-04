using Microservices.Catalog.Data.Contexts;
using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Microservices.Catalog.Api.Controllers
{
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogContext> _logger;

        public CatalogController(IProductRepository repository, ILogger<CatalogContext> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _repository.Create(product);
            if (product.Id == null) return BadRequest();
            return CreatedAtRoute("product", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateProduct(Product product)
        {
            var update_result = await _repository.Update(product);
            return Ok(update_result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteProduct(string id)
        {
            var delete_result = await _repository.Delete(id);
            return Ok(delete_result);
        }

        [HttpGet]
        [Route("product-by-name")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var products = await _repository.GetProductByName(name);
            return Ok(products);
        }

        [HttpGet]
        [Route("product-by-category")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductByCategory(category);
            return Ok(products);
        }

        [HttpGet("{id}", Name = "product")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _repository.GetProduct(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with id {id} not found");
                return NotFound();
            }
            return Ok(product);
        }
    }
}
