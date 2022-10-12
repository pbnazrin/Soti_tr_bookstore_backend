using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class Users
    {   public int    UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public string Address { get; set; }

        public Users()
        {

        }

        public Users(int userId, string username, string password, string name, string email, string phone, string address)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            Phone = phone; 
            Address = address;
 
        }
     }
   
}