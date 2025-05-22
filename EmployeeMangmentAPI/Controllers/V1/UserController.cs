using EmployeeMangment.Application.Query;
using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangment.API.Controllers.V1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(ISender sender,IJWTToken token) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ValidateUser([FromBody] UserLoginModel model)
        {
            var data = await sender.Send(new UserLoginQuery(model));
            if(data!=null)
            {
                var jwttoken=await token.GenerateJWTTokenAsync(model);
                return Ok(new { Token = jwttoken });
            }
            return BadRequest("User Is Not Found");
            
        }

    }
}
