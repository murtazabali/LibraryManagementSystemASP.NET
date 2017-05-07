using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyProject
{
    public class BooksDAO
    {
        public DataTable getBooksByBookId(int BookId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select * from Books where BookId = {0}", BookId);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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