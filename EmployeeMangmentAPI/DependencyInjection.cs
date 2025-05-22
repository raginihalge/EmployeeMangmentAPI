using EmployeeMangment.Application;
using EmployeeMangment.Core.Interface;
using EmployeeMangment.Core.JWT;
using EmployeeMangment.Infrastructure;

namespace EmployeeMangment.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddApplicationDI().AddInfrastructureDI();
            services.AddScoped<IJWTToken, JWTToken>();
            return services;
        }
    }
}
