using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Dto.Product;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.ProductOperations.Quieries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<ProductViewDto>>
    {
        private readonly Guid id;

        public GetProductByIdQuery(Guid id)
        {
            this.id = id;

        }

        public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(request.id);
                if (product == null)
                    return ServiceResponse<ProductViewDto>.FailureResponse("Product not found!");

                var productDto = mapper.Map<ProductViewDto>(product);
                return ServiceResponse<ProductViewDto>.SuccessResponse(productDto);
            }
        }
    }
}
