using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Core.JWT
{
    public class JWTToken(IConfiguration configuration):IJWTToken
    {
        public async Task<string> GenerateJWTTokenAsync(UserLoginModel model)
        {
            return await Task.Run(() =>
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "User")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = configuration["Jwt:Issuer"],
                    Audience = configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                // Assuming T is string (you may adjust this part based on your generic usage)
                return jwtToken.ToString();
            });
        }
    }
}
