using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangmentAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRegisterController : ControllerBase
    {
        [HttpPost("EmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            return Ok(new {Message="Employee Details" });
        }

    }
}
