using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace pjt_BookStore.Models
{
    public class LoginImpl
    {
        SqlCommand comm;
        SqlConnection conn;

        public LoginImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Users GetLogin(Login login)
        {
            Users users = new Users();
            comm.CommandText = "select * from Users where Email = '" + login.Email + "' and Password = '" + login.Password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userid = Convert.ToInt32(reader["UserId"]);
                string uname = reader["Username"].ToString();
                string pwd = reader["Password"].ToString();
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string phone = reader["Phone"].ToString();
                string address = reader["Address"].ToString();
                users = new Users(userid, uname, pwd, name, email, phone, address);
            }
            
            if (reader.HasRows != false)
            {
                conn.Close();
                return users;

            }
            conn.Close();
            return users;
          
            
        
        
        }
    }
}