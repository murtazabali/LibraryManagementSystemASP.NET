using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyProject
{
    public class ReturnDAO
    {
        public void ReturnBook(int BookId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Delete from issue where BookId = {0}", BookId);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getReturnBooks(int MemberId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select * from Books where BookId in (Select BookId from issue where MemberId = {0})", MemberId);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int getReturnBookInt(int MemberId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select IssueId from issue where MemberId = {0}", MemberId);
                SqlCommand cmd = new SqlCommand(sql, conn);
                var id = cmd.ExecuteScalar();
                if (id == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}