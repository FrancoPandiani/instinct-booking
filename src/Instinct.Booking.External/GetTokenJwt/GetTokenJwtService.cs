
using Instinct.Booking.Application.GetTokenJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Instinct.Booking.External.GetTokenJwt
{
    public class GetTokenJwtService : IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Execute(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            string key = _configuration["SecreKeyJwt"]?? string.Empty;
            // Genera una clave simétrica a partir del secreto para firmar tokens JWT
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Configura el descriptor del token JWT con claims, expiración, firma y metadatos
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim (ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["IssuerJwt"],
                Audience = _configuration["AudicenceJwt"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
