using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyProject
{
    public class MembersDAO
    {
        public DataTable getMemberById(int MemberId)
        {
            using(SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select * from Members where MemberId = {0}", MemberId);
                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}