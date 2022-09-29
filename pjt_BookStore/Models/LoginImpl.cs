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

        public int GetLogin(Login login)
        {
            comm.CommandText = "select * from Users where Username = '" + login.Username + "' and Password = '" + login.Password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            //while (reader.Read())
            //{

            //}
            //conn.Close();
            if (reader.HasRows != false)
            {
                return 1;

            }
            else
            {
                return 0;
            }
            
            
        
        
        }
    }
}