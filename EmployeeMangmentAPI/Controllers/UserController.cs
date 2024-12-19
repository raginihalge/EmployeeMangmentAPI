using EmployeeMangmentAPI.Helper;
using EmployeeMangmentAPI.Model;
using EmployeeMangmentAPI.Repositiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeMangmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUser _user;
        private readonly IEncryptionHelper _Encryption;

        public UserController(IConfiguration configuration,IUser user,IEncryptionHelper encryption)
        {
            _configuration = configuration;
            _user = user;
            _Encryption = encryption;
        }

      

        [HttpPost("Login")]
        public IActionResult UserAunthontication([FromBody] UserModel login)
        {
            // Example: Validate user credentials (implement your own logic here)
            if (login.Username != "" && login.Password != "")
            {

                //_user.CheckLogin(login);
                //login.Username=_Encryption.Encrypt(login.Username);
                string name=_Encryption.Decrypt(login.Username);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "User") // Add roles/claims as needed
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { Token = tokenHandler.WriteToken(token) });
            }

            return Unauthorized();
        }
    }
}
