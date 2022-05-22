using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Otel
{
    public class DataBase
    {
        private static DataBase instacne = null;
        private SqlConnection cnx;
        private SqlCommand cmd;
        private DataTable tb;
        private SqlDataReader red;


        private DataBase()
        {
            cnx = new SqlConnection("Data Source=DESKTOP-4T09HNO;Initial Catalog=Hootel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cmd = new SqlCommand("", cnx);
            tb = new DataTable();
        }

        public static DataBase getInstance()
        {
            if(instacne == null)
            {
                instacne = new DataBase();
            }
            return instacne; 
        }
        public DataTable executeDataTable(string sqlquery)
        {
            cnx.Open();
            cmd.CommandText = sqlquery;
            tb.Clear();
            tb.Load(cmd.ExecuteReader());
            cnx.Close();
            return tb.Copy();
        }
        public int executeNonQuery(string query)
        {
            cnx.Open();
            cmd.CommandText = query;
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;
        }
        public object executeScalar(string query)
        {
            cnx.Open();
            cmd.CommandText = query;
            object obj = cmd.ExecuteScalar();
            cnx.Close();
            return obj;
        }
        public bool Login(string UserName,string Password,string LogType)
        {
            
            if(LogType == "Admin")
            {
                cnx.Open();
                cmd.CommandText = "SELECT adminUserName,adminPw FROM dbo.Administration" +
                     " WHERE adminUserName = @UserName and adminPw = @Password ";
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                red = cmd.ExecuteReader();
                if (red.Read())
                {
                    cmd.Parameters.Clear();
                    cnx.Close();
                    return true;
                }
                else
                {
                    cmd.Parameters.Clear(); 
                    cnx.Close();
                    return false;
                }
            }
            else if(LogType == "Personel")
            {
                cnx.Open();
                cmd.CommandText = "SELECT staffUserName,staffPw FROM dbo.Staffs" +
                     " WHERE staffUserName = @UserName and staffPw = @Password ";
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                red = cmd.ExecuteReader();
                if (red.Read())
                {
                    cmd.Parameters.Clear();
                    cnx.Close();

                    return true;
                }
                else
                {
                    cmd.Parameters.Clear();
                    cnx.Close();

                    return false;
                }
            }
            else if(LogType == "Customer")
            {
                cnx.Open();
                cmd.CommandText = "SELECT customerUserName,customerPw FROM dbo.Customer" +
                     " WHERE customerUserName = @UserName and customerPw = @Password ";
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                red = cmd.ExecuteReader();
                if (red.Read())
                {
                    cmd.Parameters.Clear();
                    cnx.Close();
                    return true;
                }
                else
                {
                    cmd.Parameters.Clear();
                    cnx.Close();
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
        
    }

}
