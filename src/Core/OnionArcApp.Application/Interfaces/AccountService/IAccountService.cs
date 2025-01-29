using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcApp.Application.Interfaces.AccountService
{
    public interface IAccountService
    {
        Task<string> CreateAccountNumber();
    }
}
