using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace pjt_BookStore.Models
{
    public class UsersSqlImpl:IUserRepository
    {
        SqlCommand comm;
        SqlConnection conn;
        public UsersSqlImpl()
        {
            comm = new SqlCommand();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDb"].ConnectionString);
        }

        Users IUserRepository.AddUser(Users users)
        {
            comm.CommandText = $"insert into Users values('{users.Username}','{users.Password}','{users.Name}','{users.Email}','{users.Phone}','{users.Address}')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if(row>0)
            {
                return users;
            }
            else
            {
                return null;
            }
        }

        void IUserRepository.DeleteUsers(int id)
        {
            comm.CommandText = "Delete from Users where UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        List<Users> IUserRepository.GetAllUsers()
        {
            List<Users> list = new List<Users>();
            comm.CommandText = "select * from Users";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int    userid = Convert.ToInt32(reader["UserId"]);
                string uname = reader["Username"].ToString();
                string pwd = reader["Password"].ToString();
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string  phone = reader["Phone"].ToString();
                string address = reader["Address"].ToString();
                list.Add(new Users(userid, uname, pwd, name, email, phone, address));
            }
            conn.Close();
            return list;
        }

        Users IUserRepository.GetUsersById(int id)
        {
            Users users = new Users();
            comm.CommandText = "select * from users where UserId = " + id;
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
            conn.Close();
            return users;
        }

        void IUserRepository.UpdateUsers(Users users)
        {
            comm.CommandText = $"Update Users set Username='{users.Username}',Password='{users.Username}',Name = '{users.Name}',Email='{users.Email}'," +
                $"'Phone={users.Phone}',Address='{users.Address}' where UserId ={users.UserId}')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        void IUserRepository.AddToWishList(int userId, int bookId)
        {
            comm.CommandText = $"insert into WishList values({userId},{bookId}";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            
        }
        List<WishList> IUserRepository.ViewWishList(int userid)
        {
            List<WishList> list = new List<WishList>();
            comm.CommandText = "select * from WishList";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int wishId= Convert.ToInt32(reader["WishListId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                
                int bookId = Convert.ToInt32(reader["Phone"]);
                
                list.Add(new WishList(wishId, userId, bookId));
            }
            conn.Close();
            return list;
        }

    }
}