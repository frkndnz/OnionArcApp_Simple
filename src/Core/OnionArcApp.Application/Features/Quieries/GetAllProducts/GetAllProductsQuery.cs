
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Dto.Product;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.Quieries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;
            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products =await productRepository.GetAllAsync();
                if(!products.Any())
                    return ServiceResponse<List<ProductViewDto>>.FailureResponse("Not found products!");

                var dto = mapper.Map<List<ProductViewDto>>(products);

                return ServiceResponse<List<ProductViewDto>>.SuccessResponse(dto);
            }
        }
    }
}
