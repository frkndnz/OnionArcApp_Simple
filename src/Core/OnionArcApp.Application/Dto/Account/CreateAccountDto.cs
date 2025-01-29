using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Enums;

namespace OnionArcApp.Application.Dto.Account
{
    public sealed class CreateAccountDto
    {
       public AccountType AccountType { get; set; }
    }
}
