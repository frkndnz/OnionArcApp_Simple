﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Dto.Product;
using OnionArcApp.Application.Dto.Transaction;
using OnionArcApp.Application.Dto.User;
using OnionArcApp.Application.Features.AccountOperations.Commands.CreateAccount;
using OnionArcApp.Application.Features.ProductOperations.Commands.CreateProduct;
using OnionArcApp.Application.Features.UserOperations.Commands.CreateUser;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();

            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            CreateMap<User, UserForTokenDto>()
                .ForMember(dest=>dest.RoleName,opt=>opt.MapFrom(src=>src.Role!.RoleName));

            CreateMap<CreateAccountCommand, Account>();
            CreateMap<CreateAccountDto, Account>();
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.TransactionCount, opt => opt.MapFrom(src => src.Transactions.Count));

            CreateMap<Transaction, TransactionDto>();

        }
    }
}
