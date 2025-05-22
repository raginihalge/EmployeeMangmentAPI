using EmployeeMangment.Core.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeMangment.Infrastructure.Data
{
    public class DALRepository(IDALConnectionRepository repositiory): IDALRepository
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
                cmd.CommandType=CommandType.StoredProcedure;
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    dt.Load(reader); // unfortunately, DataTable.Load is still sync
                }
            }
            catch (Exception ex)
            {
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
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                result = rowsAffected > 0;
            }
            catch (Exception ex)
            {
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
    }
}
