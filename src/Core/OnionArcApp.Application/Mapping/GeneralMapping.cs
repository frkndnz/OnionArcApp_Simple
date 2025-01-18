using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArcApp.Application.Dto.Product;
using OnionArcApp.Application.Features.Commands.CreateProduct;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product,ProductViewDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
