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
        public OrderItems AddOrderItems(OrderItems items)
        {
            comm.CommandText = $"Insert into OrderItems values ({items.ItemId},{items.OrderId},{items.BookId},{items.BookPrice})";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return items;
            }
            else
            {
                return null;
            }
        }

        public void DeleteOrderItems(int id)
        {
            comm.CommandText = "Delete from OrderItems where ItemId=" + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<OrderItems> GetAllOrderItems()
        {
            List<OrderItems> list = new List<OrderItems>();
            comm.CommandText = "select * from OrderItems";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int itemId = Convert.ToInt32(reader["ItemId"]);
                int orderId = Convert.ToInt32(reader["OrderId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int price = Convert.ToInt32(reader["BookPrice"]);
               

                list.Add(new OrderItems(itemId, orderId, bookId, price));
            }
            conn.Close();
            return list;
        }

        public OrderItems GetOrderItemsByID(int id)
        {
            OrderItems items = new OrderItems();
            comm.CommandText = "select * from OrderItems where OrderId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int itemId = Convert.ToInt32(reader["ItemId"]);
                int orderId = Convert.ToInt32(reader["OrderId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int price = Convert.ToInt32(reader["BookPrice"]);




                items = new  OrderItems(itemId, orderId, bookId, price);

            }
            conn.Close();
            if (items.OrderId == 0)
            {
                return null;
            }
            else
            {
                return items;
            }
        }

        public void UpdateOrderItems(OrderItems items)
        {
            comm.CommandText = $"Update OrderItems set OrderId ={items.OrderId},BookId = {items.BookId},BookPrice = {items.BookPrice} where ItemId ="+ items.ItemId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}