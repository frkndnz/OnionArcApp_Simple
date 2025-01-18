using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Dto.Product;
using OnionArcApp.Application.Features.Commands.CreateProduct;
using OnionArcApp.Application.Features.Quieries.GetAllProducts;
using OnionArcApp.Application.Features.Quieries.GetProductById;
using OnionArcApp.Application.Interfaces.Repository;

namespace OnionArcApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var result=  await mediator.Send(createProductCommand);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
