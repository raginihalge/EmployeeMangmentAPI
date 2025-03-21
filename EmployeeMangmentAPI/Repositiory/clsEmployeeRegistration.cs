using DAL;
using EmployeeMangmentAPI.Model;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace EmployeeMangmentAPI.Repositiory
{
    public class clsEmployeeRegistration : IEmployeeRegistration
    {
        private readonly IDAL _dal;

        public clsEmployeeRegistration(IDAL dal)
        {
            _dal = dal;
        }
        public int Id { get; set; }
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

        public int InsertEmployeeRegistration(EmployeeRegistrationModel EmpRegister)
        {
            //Add New Method
            SqlCommand cmd = new SqlCommand("SP_SetEmployeeRegistration");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", EmpRegister.Name);
            cmd.Parameters.AddWithValue("@Address", EmpRegister.Address);
            cmd.Parameters.AddWithValue("@City", EmpRegister.City);
            cmd.Parameters.AddWithValue("@PinCode", EmpRegister.PinCode);
            cmd.Parameters.AddWithValue("@MobileNumber", EmpRegister.MobileNumber);
            cmd.Parameters.AddWithValue("@EmailID", EmpRegister.EmailID);
            cmd.Parameters.AddWithValue("@UserName", EmpRegister.UserName);
            cmd.Parameters.AddWithValue("@Password", EmpRegister.Password);
            cmd.Parameters.AddWithValue("@Gender", EmpRegister.Gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", EmpRegister.DateOfBirth);

            //DataTable dt = _dAL.GetData(cmd);
            //_dAL.Excute(cmd);
            // Add output parameter
            SqlParameter outputParam = new SqlParameter("@ID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            // Execute the command
            _dal.Excute(cmd);

            // Retrieve the value of the output parameter
            int ID = (int)outputParam.Value;
            return ID;
        }
    }
}
