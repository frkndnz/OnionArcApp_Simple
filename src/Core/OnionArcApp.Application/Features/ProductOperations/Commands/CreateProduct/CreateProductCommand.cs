using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using OnionArcApp.Application.Dto.Product;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Features.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public CreateProductCommand(string name, decimal value, int quantity)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
        }



        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;
            private readonly IValidator<CreateProductCommand> validator;
            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IValidator<CreateProductCommand> validator)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
                this.validator = validator;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var validatorResult = validator.Validate(request);
                if (validatorResult.IsValid == false)
                {
                    return ServiceResponse<Guid>.ValidationFailedResponse(validatorResult.Errors);
                }

                var product = mapper.Map<Product>(request);
                await productRepository.AddAsync(product);

                return ServiceResponse<Guid>.SuccessResponse(product.Id);

            }
        }
    }
}
