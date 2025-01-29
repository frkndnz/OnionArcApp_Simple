using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcApp.Application.Dto.User
{
    public class UserForTokenDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
    }
}
