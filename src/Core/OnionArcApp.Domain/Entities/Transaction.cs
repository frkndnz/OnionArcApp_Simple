using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Common;
using OnionArcApp.Domain.Enums;

namespace OnionArcApp.Domain.Entities
{
    public class Transaction:BaseEntity
    {
        
        public Account Account { get; set; }
        
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate {  get; set; }
        public string? Description { get; set; }

        
        public Account? TargetAccount { get; set; }
        
    }
}
