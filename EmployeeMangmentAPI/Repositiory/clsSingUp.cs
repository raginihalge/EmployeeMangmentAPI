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

        public int InsertSingUp(SingUpModel singUp)
        {
            //Add New Method
            SqlCommand cmd = new SqlCommand("SP_SetEmpRegistration");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", singUp.UserName);
            cmd.Parameters.AddWithValue("@Password", singUp.Password);
            cmd.Parameters.AddWithValue("@EmailID", singUp.EmailID);
            cmd.Parameters.AddWithValue("@MobileNumber", singUp.MobileNumber);
            //DataTable dt = _dAL.GetData(cmd);
            //_dAL.Excute(cmd);
            // Add output parameter
            SqlParameter outputParam = new SqlParameter("@ID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            // Execute the command
            _dAL.Excute(cmd);

            // Retrieve the value of the output parameter
            int ID = (int)outputParam.Value;
            return ID;
        }
    }
}
