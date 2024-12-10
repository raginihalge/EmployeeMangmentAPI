using DAL;
using EmployeeMangmentAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeMangmentAPI.Repositiory
{
    public class clsUser: IUser
    {
        private readonly IDAL _dAL;

        public clsUser(IDAL dAL)
        {
            _dAL = dAL;
        }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public void CheckLogin(UserModel user)
        {
            //Add New Method
            SqlCommand cmd = new SqlCommand("GetSP");
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = _dAL.GetData(cmd);
        }
    }
}
