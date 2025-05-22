using EmployeeMangment.Application.Command;
using EmployeeMangment.Core.Model;
using EmployeeMangmentAPI.Helper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangment.API.Controllers.V1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignUpController(ISender sender,IEncryptionHelper encryption) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> SignUpUser([FromBody] SignUpModel model)
        {
            model.UserName=encryption.Encrypt(model.UserName);
            model.Password=encryption.Encrypt(model.Password);
            var data = await sender.Send(new SignUpCommand(model));
            return Ok(data);
        }
    }
}
