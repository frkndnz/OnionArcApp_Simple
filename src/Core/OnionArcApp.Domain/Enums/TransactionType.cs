using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcApp.Domain.Enums
{
    public enum TransactionType
    {
        Deposit = 0, // yatırma
        Withdrawal = 1, // para çekme
        Transfer = 2,  // para transferi
    }
}
