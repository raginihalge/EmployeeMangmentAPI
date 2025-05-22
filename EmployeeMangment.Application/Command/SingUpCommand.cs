using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Application.Command
{
    public record SignUpCommand(SignUpModel Model):IRequest<ResponseModel>;
    public class SignUpCommandHandler(ISignUpRepository repository):
        IRequestHandler<SignUpCommand,ResponseModel>
    {
        public async Task<ResponseModel> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            return await repository.SignUpUserAsync(request.Model);
        }

    }
}
