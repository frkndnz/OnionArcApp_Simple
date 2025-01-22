using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionArcApp.Application.Dto.Token;
using OnionArcApp.Application.Dto.User;
using OnionArcApp.Application.Interfaces.Token;

namespace OnionArcApp.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto CreateAccessToken(UserForTokenDto userForTokenDto )
        {
            TokenDto tokenDto = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            tokenDto.Expiration = DateTime.UtcNow.AddMinutes(Convert.ToInt16(_configuration["Token:Expiration"]));

            var claimsArr = new Claim[]
            {
                new Claim(ClaimTypes.Name,userForTokenDto.Name),
                new Claim(ClaimTypes.Role,userForTokenDto.RoleName)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: tokenDto.Expiration,
                claims:claimsArr,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtTokenHandler = new();
            tokenDto.AccessToken=jwtTokenHandler.WriteToken(jwtSecurityToken);

            return tokenDto;
        }
    }
}
