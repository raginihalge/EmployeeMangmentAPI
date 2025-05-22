using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Core.Interface
{
    public interface IDALRepository
    {
        Task<DataTable> GetDataAsync(SqlCommand cmd);
        Task<bool> ExecuteAsync(SqlCommand cmd);
    }
}
