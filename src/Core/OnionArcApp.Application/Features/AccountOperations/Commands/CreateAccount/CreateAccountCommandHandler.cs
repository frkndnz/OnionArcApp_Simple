using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Interfaces.AccountService;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Features.AccountOperations.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, ServiceResponse<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;


        public CreateAccountCommandHandler(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper, IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                ServiceResponse<Guid>.FailureResponse("user not found!");


            var accountNumber = await _accountService.CreateAccountNumber();

            var account = _mapper.Map<Account>(request.CreateAccountDto);
            account.User = user!;
            account.AccountNumber = accountNumber;
            // Create Account Number


            var addedAccount =await _accountRepository.AddAsync(account);
            
            return ServiceResponse<Guid>.SuccessResponse(addedAccount.Id);
        }
    }
}
