using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Dto;
using OnionArcApp.Application.Interfaces.Repository;

namespace OnionArcApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
          var allList= await  productRepository.GetAllAsync();

            var dtoList = allList.Select(x => new ProductViewDto
            {
                Id = x.Id,
                Name= x.Name,
            });

            return Ok(dtoList);
        }
    }
}
