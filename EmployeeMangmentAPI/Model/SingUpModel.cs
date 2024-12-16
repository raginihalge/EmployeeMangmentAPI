using DAL;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeMangmentAPI.Model
{
    public class SingUpModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
    }
}
