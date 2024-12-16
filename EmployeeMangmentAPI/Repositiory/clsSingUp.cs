using DAL;
using EmployeeMangmentAPI.Model;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeMangmentAPI.Repositiory
{
    public class clsSingUp: ISingUp
    {
        private readonly IDAL _dAL;

        public clsSingUp(IDAL dAL)
        {
            _dAL = dAL;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }

        public void InsertSingUp(SingUpModel singUp)
        {
            //Add New Method
            SqlCommand cmd = new SqlCommand("GetSP");
            cmd.Parameters.AddWithValue("UserName", singUp.UserName);
            cmd.Parameters.AddWithValue("Password", singUp.Password);
            cmd.Parameters.AddWithValue("EmailID", singUp.EmailID);
            cmd.Parameters.AddWithValue("MobileNumber", singUp.MobileNumber);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = _dAL.GetData(cmd);
        }
    }
}
