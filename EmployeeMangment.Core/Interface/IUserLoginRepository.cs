using EmployeeMangment.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Core.Interface
{
    public interface IUserLoginRepository
    {
        Task<ResponseModel> ValidateUserLogin(UserLoginModel user);
    }
}
