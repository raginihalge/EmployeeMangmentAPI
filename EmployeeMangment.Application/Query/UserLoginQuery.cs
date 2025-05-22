using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Application.Query
{
    public record UserLoginQuery(UserLoginModel Model):IRequest<ResponseModel>;
    public class UserLoginQueryHandler(IUserLoginRepository repositiory):
        IRequestHandler<UserLoginQuery,ResponseModel>
    {
        public async Task<ResponseModel> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            return await repositiory.ValidateUserLogin(request.Model);
        }
    }
}
