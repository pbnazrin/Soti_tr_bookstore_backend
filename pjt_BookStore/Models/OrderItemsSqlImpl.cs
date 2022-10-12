using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace pjt_BookStore.Models
{
    public class OrderItemsSqlImpl : IOrderItemsRepository
    {
        SqlCommand comm;
        SqlConnection conn;

        public OrderItemsSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDb"].ConnectionString);
            comm = new SqlCommand();
        }
        public OrderItems AddOrderItems(int userid,OrderItems book)
        {
            comm.CommandText = $"Insert into Cart values ({userid},{book.BookId},{book.CategoryId},'{book.Title}','{book.Author}',{book.ISBN},{book.Year},{book.Price},'{book.Description}',{book.Position},{book.Status} ,'{book.Image}')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public void DeleteOrderItems(int userid,int bookid)
        {
            comm.CommandText = $"Delete from Cart where BookId={bookid}and Userid = {userid}";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<OrderItems> GetAllOrderItems()
        {
            List<OrderItems> list = new List<OrderItems>();
            comm.CommandText = "select * from Cart";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["OrderId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string image = reader["Image"].ToString();


                list.Add(new OrderItems(orderId,userId,bookId, categoryId, title, author, isbn, year, price, description, position, status, image));
            }
            conn.Close();
            return list;
        }

        public List<OrderItems> GetOrderItemsByID(int id)
        {
            List<OrderItems> items = new List<OrderItems>();
            comm.CommandText = "select * from Cart where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cartId = Convert.ToInt32(reader["CartId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string image = reader["Image"].ToString();
                items.Add(new OrderItems(cartId, userId, bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();
            //if (items.BookId == 0)
            //{
            //    return null;
            //}
            //else
            //{
                return items;
            //}
        }

        //public void UpdateOrderItems(OrderItems items)
        //{
        //    comm.CommandText = $"Update OrderItems set OrderId ={items.OrderId},BookId = {items.BookId},BookPrice = {items.BookPrice} where ItemId ="+ items.ItemId;
        //    comm.Connection = conn;
        //    conn.Open();
        //    int row = comm.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}