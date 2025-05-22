using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Infrastructure.Repositiory
{
    public class UserLoginRepository(IDALRepository repositiory): IUserLoginRepository
    {
        public async Task<ResponseModel> ValidateUserLogin(UserLoginModel user)
        {
            SqlCommand cmd = new SqlCommand("SP_CheckUserValidation");
            cmd.Parameters.AddWithValue("@UserName", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            DataTable dt= await repositiory.GetDataAsync(cmd);
            ResponseModel responseModel = new ResponseModel()
            {
                Code=2,
                Message="Success",
                Data=dt
            };
            return responseModel;

        }
    }
}
