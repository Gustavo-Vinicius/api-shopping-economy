using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace shopping_economy.Infrastructure.Persistence.Service
{
    public class TokenService : ITokenService
    {
        private const int ACCESS_TOKEN_DURATION_IN_HOURS = 1;
        private readonly IConfiguration _configuration;
        private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private byte[] GetPrivateKey()
        {
            return Encoding.ASCII.GetBytes(_configuration.GetSection("SecretKey").Value);
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;
            validationParameters.ValidateAudience = false;
            validationParameters.ValidateIssuer = false;

            validationParameters.IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(GetPrivateKey());

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
        public string GenerateAccessToken(string email)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = (DateTime.Now.AddHours(ACCESS_TOKEN_DURATION_IN_HOURS).ToUniversalTime()),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(GetPrivateKey()), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("Email", email)
                }),
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            var tokenWrite = _tokenHandler.WriteToken(token);

            return tokenWrite;
        }

        public Employee ReadToken(string jwtToken)
        {
           Employee tokenDTO = new Employee();

            var Claims = ValidateToken(jwtToken).Claims;

            tokenDTO.Email = Claims.FirstOrDefault(p => p.Type == "Email").Value;

            return tokenDTO;
        }
    }
}