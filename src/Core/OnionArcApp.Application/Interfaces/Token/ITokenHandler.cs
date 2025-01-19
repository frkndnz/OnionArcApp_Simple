using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Application.Dto.Token;

namespace OnionArcApp.Application.Interfaces.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken();
    }
}
