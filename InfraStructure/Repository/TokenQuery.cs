using AssesementWebAPI.Domain.Models;
using AssesementWebAPI.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AssesementWebAPI.InfraStructure.Repository
{
    public class TokenQuery : ITokenQuery
    {

        private readonly DataContext _context;
        private IConfiguration _config;
        public TokenQuery(DataContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<Token> GetToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return new Token { TokenString = tokenString };
        }

    }
}
