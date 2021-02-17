using catalogs.api.Entities;
using catalogs.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using catalogs.api.Data;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace catalogs.api
{
    [Route("api/v1/[controller]")]
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
            if(product.Id == null) return BadRequest();
            return CreatedAtRoute("GetProduct",new { id = product.Id }, product);
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
        [Route("GetProductByName")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var products = await _repository.GetProductByName(name);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductByCategory(category);
            return Ok(products);
        }

        [HttpGet("{id}",Name = "GetProduct")]
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
