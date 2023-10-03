using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DinnerBooking.Application.Common.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;

namespace DinnerBooking.Infrastructure.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("The+Brown-fox?goes*TO#The_Coffee=Shoppe")),
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: "DinnerBooking",
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}