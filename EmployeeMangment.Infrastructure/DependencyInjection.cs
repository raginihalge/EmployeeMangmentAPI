using EmployeeMangment.Core.Interface;
using EmployeeMangment.Infrastructure.Data;
using EmployeeMangment.Infrastructure.Repositiory;
using EmployeeMangment.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped<IDALConnectionRepository, DALConnectionRepository>();
            services.AddScoped<IDALRepository, DALRepository>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<ISignUpRepository, SignUpRepository>();
            return services;
        }
    }
}
