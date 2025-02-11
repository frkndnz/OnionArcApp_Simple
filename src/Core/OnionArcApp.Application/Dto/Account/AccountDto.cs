using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Enums;

namespace OnionArcApp.Application.Dto.Account
{
    public sealed class AccountDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; } 
        public decimal Balance { get; set; }
        public int TransactionCount { get; set; }
    }
}
