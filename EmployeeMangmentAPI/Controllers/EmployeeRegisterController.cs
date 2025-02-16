using EmployeeMangmentAPI.Model;
using EmployeeMangmentAPI.Repositiory;
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
        private readonly ISingUp _singUp;
        private readonly IEmployeeRegistration employeeRegistration;

        public EmployeeRegisterController(ISingUp singUp)
        {
            _singUp = singUp;
        }

        [HttpPost("EmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            return Ok(new {Message="Employee Details" });
        }
        [HttpPost("EmployeeSignUp")]
        public IActionResult EmployeeSignUp([FromBody] SingUpModel signUp)
        {
            int ID=_singUp.InsertSingUp(signUp);
            return Ok(new {Message=$"Employee Created Succesfully {ID}"});
        }

    }
}
