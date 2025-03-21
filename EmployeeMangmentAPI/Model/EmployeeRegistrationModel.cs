using System.ComponentModel.DataAnnotations;

namespace EmployeeMangmentAPI.Model
{
    public class EmployeeRegistrationModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public string DateOfBirth { get; set; }
    }
}
