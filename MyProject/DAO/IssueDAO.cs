using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyProject
{
    public class IssueDAO
    {
        public void InsertIssueBook(int BookId,int MemberId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Insert into issue (BookId,MemberId) values ({0},{1})", BookId, MemberId);
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getIssuedBooks(int MemberId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select title from Books where BookId in (Select BookId from issue where MemberId = {0})",MemberId);
                SqlDataAdapter da = new SqlDataAdapter(sql,conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;           
            }
        }

        public int getIssueBookInt(string title)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select BookId from Books where title like '{0}'",title);
                SqlCommand cmd = new SqlCommand(sql, conn);
                var id = cmd.ExecuteScalar();
                int id1 = (int)id;
                return id1;
            }
        }

        public int IssuedBooks(int BookId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("select count(*) from issue where bookid = {0}",BookId);
                SqlCommand cmd = new SqlCommand(sql, conn);
                var count = cmd.ExecuteScalar();
                int Count = (int)count;
                if (Count == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int BooksCondition(int MemberId)
        {
            using (SqlConnection conn = DB.getSqlConnection())
            {
                String sql = String.Format("Select Count(*) from Issue where MemberId = {0}", MemberId);
                SqlCommand cmd = new SqlCommand(sql, conn);
                var count = cmd.ExecuteScalar();
                int count1 = (int)count;
                return count1;
            }
        }
    }
}