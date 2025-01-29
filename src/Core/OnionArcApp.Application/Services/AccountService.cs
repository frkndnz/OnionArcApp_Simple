using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Application.Interfaces.AccountService;

namespace OnionArcApp.Application.Services
{
    public class AccountService : IAccountService
    {
        public async Task<string> CreateAccountNumber()
        {
            return await Task.Run(() =>
            {
                byte[] bytes = new byte[4];
                RandomNumberGenerator.Fill(bytes);
                int randomNumber = BitConverter.ToInt32(bytes, 0) & int.MaxValue;
                return randomNumber.ToString("D10");
            });


        }
    }
}
