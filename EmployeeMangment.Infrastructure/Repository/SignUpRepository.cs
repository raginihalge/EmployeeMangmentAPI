using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Infrastructure.Repository
{
    public class SignUpRepository(IDALRepository repository): ISignUpRepository
    {
        public async Task<ResponseModel> SignUpUserAsync(SignUpModel model)
        {
            SqlCommand cmd = new SqlCommand("SP_SetSignUpUser");
            cmd.Parameters.AddWithValue("@UserName", model.UserName);
            cmd.Parameters.AddWithValue("@Password",model.Password);
            cmd.Parameters.AddWithValue("@EmailID", model.EmailID);
            cmd.Parameters.AddWithValue("@MobileNumber", model.MobileNumber);
            SqlParameter outParam = new SqlParameter("@Message",SqlDbType.NVarChar,200);
            outParam.Direction=ParameterDirection.Output;
            cmd.Parameters.Add(outParam);
            bool result= await repository.ExecuteAsync(cmd);
            return new ResponseModel()
            {
                Code = 200,
                Data = outParam.Value.ToString(),
            };
        }
    }
}
