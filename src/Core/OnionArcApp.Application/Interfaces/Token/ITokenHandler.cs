using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Application.Dto.Token;
using OnionArcApp.Application.Dto.User;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Interfaces.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(UserForTokenDto userForTokenDto);
    }
}
