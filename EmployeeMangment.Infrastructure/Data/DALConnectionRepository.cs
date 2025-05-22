using EmployeeMangment.Core.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeMangment.Infrastructure.Data
{
    public class DALConnectionRepository(IConfiguration configuration): IDALConnectionRepository
    {
        public SqlConnection GetConnection()
        {
            var connectionstring = configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionstring);
        }
    }
}
