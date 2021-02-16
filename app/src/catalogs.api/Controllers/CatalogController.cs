﻿using catalogs.api.Entities;
using catalogs.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public CatalogController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task CreateProduct(Product product)
        {
            await _repository.Create(product);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProduct(Product product)
        {
            var update_result = await _repository.Update(product);
            return Ok(update_result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(string id)
        {
            var delete_result = await _repository.Delete(id);
            return Ok(delete_result);
        }

        [HttpGet]
        [Route("GetProductByName")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var products = await _repository.GetProductByName(name);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductByCategory")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductByCategory(category);
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _repository.GetProduct(id);
            return Ok(product);
        }        
    }
}
