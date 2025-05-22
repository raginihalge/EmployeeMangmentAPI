using EmployeeMangment.Core.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text;

namespace EmployeeMangment.Infrastructure.Data
{
    public class DALRepository(IDALConnectionRepository repositiory, ILogger<DALRepository> logger) : IDALRepository
    {
        public async Task<DataTable> GetDataAsync(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlConnection con = repositiory.GetConnection();

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    await con.OpenAsync();
                }
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                LogSqlCommandDetails(cmd, logger);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GetDataAsync for Stored Procedure: {ProcedureName}", cmd.CommandText);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    await con.CloseAsync();
                }
            }
            return dt;
        }

        public async Task<bool> ExecuteAsync(SqlCommand cmd)
        {
            bool result = false;
            SqlConnection con = repositiory.GetConnection();

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    await con.OpenAsync();
                }
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                LogSqlCommandDetails(cmd, logger);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                result = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in ExecuteAsync for Stored Procedure: {ProcedureName}", cmd.CommandText);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    await con.CloseAsync();
                }
            }
            return result;
        }

        public static void LogSqlCommandDetails(SqlCommand cmd, ILogger logger)
        {
            var logMessage = new StringBuilder();
            logMessage.AppendLine($"Executing Stored Procedure: {cmd.CommandText}");

            foreach (SqlParameter param in cmd.Parameters)
            {
                logMessage.AppendLine($"  {param.ParameterName} = {param.Value}");
            }

            logger.LogInformation(logMessage.ToString());
        }
    }
}
