using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class clsDAL:IDAL
    {
        private readonly IDALCon _dALCon;

        public clsDAL(IDALCon dALCon) {
            _dALCon = dALCon;
        }
        
        public DataTable GetData(SqlCommand cmd)
        {
            SqlConnection con= _dALCon.GetConnection();
            DataTable dt = new DataTable();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return dt;
        }
        public bool Excute(SqlCommand cmd)
        {
            bool result = false;
            SqlConnection con = _dALCon.GetConnection();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() != 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return result;
        }
    }
}
