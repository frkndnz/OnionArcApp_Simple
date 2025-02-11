using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnionArcApp.Application.Features.ProductOperations.Commands.CreateProduct;
using OnionArcApp.Application.Features.ProductOperations.Quieries.GetAllProducts;
using OnionArcApp.Application.Features.ProductOperations.Quieries.GetProductById;



namespace OnionArcApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
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
