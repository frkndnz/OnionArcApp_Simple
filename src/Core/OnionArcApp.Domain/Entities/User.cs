using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Common;

namespace OnionArcApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }
        
        public List<Account> Accounts { get; set; }
    }
}
