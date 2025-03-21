using EmployeeMangmentAPI.Model;
using EmployeeMangmentAPI.Repositiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRegistrationController : Controller
    {
        private readonly IEmployeeRegistration _employeeRegistration;

        public EmployeeRegistrationController(IEmployeeRegistration employeeRegistration)
        {
            _employeeRegistration = employeeRegistration;
        }


        [HttpPost("EmployeeRegistration")]
        public IActionResult EmployeeRegistration([FromBody] EmployeeRegistrationModel EmpRegister)
        {
            int ID = _employeeRegistration.InsertEmployeeRegistration(EmpRegister);
            return Ok(new { Message = $"Employee Created Succesfully {ID}" });
        }
    }
}
