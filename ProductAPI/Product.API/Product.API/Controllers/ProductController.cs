using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.API.Infrastructure;
using Product.API.Models;
using Product.API.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _mediator.Send(new GetProductQuery
            {
                Id = id
            });
            if (product == null)
                return NotFound("Record not found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductPostRequestModel item)
        {
            var product = await _mediator.Send(new CreateProductCommand
            {
                Name = item.Name,
                Price = item.Price,
                Cost = item.Cost,
                Image = item.Image,
            });
            return Ok(product);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ProductPutRequestModel item)
        {
            var product = await _mediator.Send(new UpdateProductCommand
            {
                Id = id,
                Name = item.Name,
                Price = item.Price,
                Cost = item.Cost,
                Image = item.Image,
            });
            if (product == null)
                return NotFound("Record not found");
            return Ok(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _mediator.Send(new DeleteProductQuery
            {
                Id = id,
            });
            if (product == null)
                return NotFound("Record not found");
            return Ok(product);
        }
    }
}