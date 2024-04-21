using Microsoft.IdentityModel.Tokens;
using StudentCourseCore.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace StudentCourseWebApi.JWTHelper
{
   
    public class JWTAuthHelper:IJWTAuthHelper
    {
        private readonly IConfiguration _configuration1;

        public JWTAuthHelper(IConfiguration configuration1)
        {
            _configuration1 = configuration1;
        }

        //ConfigurationManager configuration1 = new ConfigurationManager();
        
        public string GenerateJWTToken(SystemUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
                new Claim(ClaimTypes.Name,user.name),
                new Claim(ClaimTypes.Email,user.email),
            };
            var secret = _configuration1["ApplicationSettings:JWT_Secret"];
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secret)
                    ),
                    SecurityAlgorithms.HmacSha256Signature
                    )
        );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
