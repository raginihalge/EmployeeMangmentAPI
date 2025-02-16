using System.ComponentModel.DataAnnotations;

namespace EmployeeMangmentAPI.Model
{
    public class EmployeeRegistrationModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
    }
}
