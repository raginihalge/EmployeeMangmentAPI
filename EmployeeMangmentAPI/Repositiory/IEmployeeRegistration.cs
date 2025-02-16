using EmployeeMangmentAPI.Model;

namespace EmployeeMangmentAPI.Repositiory
{
    public interface IEmployeeRegistration
    {
        int InsertEmployeeRegistration(EmployeeRegistrationModel EmpRegister);
    }
}
