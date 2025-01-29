using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Common;
using OnionArcApp.Domain.Enums;

namespace OnionArcApp.Domain.Entities
{
    public class Account:BaseEntity
    {
        public User User { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; } = 0;
        public string AccountNumber { get; set; } 
        
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
