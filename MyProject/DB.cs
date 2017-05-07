using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyProject
{
    public class DB
    {
        public static string _connStr
        {
            get
            {
                return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"E:\\SZABIST\\Prev Semesters\\5th Semester\\WE\\Lab Projects\\MyProject3\\MyProject\\App_Data\\LMS.mdf\"; Integrated Security = True";
            }
        }
        public static SqlConnection getSqlConnection()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            return conn;
        }
    }
}