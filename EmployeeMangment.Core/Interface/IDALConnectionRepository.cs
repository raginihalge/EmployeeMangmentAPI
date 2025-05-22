using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Core.Interface
{
    public interface IDALConnectionRepository
    {
        SqlConnection GetConnection();
    }
}
