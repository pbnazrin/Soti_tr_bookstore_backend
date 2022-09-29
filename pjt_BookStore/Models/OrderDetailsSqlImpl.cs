using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace pjt_BookStore.Models
{
    public class OrderDetailsSqlImpl : IOrderDetailsRepository
    {
        SqlCommand comm;
        SqlConnection conn;
        public OrderDetailsSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDb"].ConnectionString);
            comm = new SqlCommand();
        }
        public OrderDetails AddOrderDetails(OrderDetails order)
        {
            comm.CommandText = $"Insert into OrderDetails values ({order.OrderId},{order.UserId},'{order.CouponCode}','{order.ShippingAddress}',{order.OrderPrice})";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public void DeleteOrderDetails(int id)
        {
            comm.CommandText = "Delete from OrderDetails where OrderId=" + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<OrderDetails> GetAllOrderDetails()
        {
            List<OrderDetails> list = new List<OrderDetails>();
            comm.CommandText = "select * from OrderDetails";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["OrderId"]);
                int uId = Convert.ToInt32(reader["UserId"]);
                string coupon = reader["CouponCode"].ToString();
                string address = reader["ShippingAddress"].ToString();
                int price = Convert.ToInt32(reader["OrderPrice"]);
               


                list.Add(new OrderDetails(id,uId,coupon,address,price));
            }
            conn.Close();
            return list;
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            OrderDetails order = new OrderDetails();
            comm.CommandText = "select * from OrderDetails where OrderId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int oid = Convert.ToInt32(reader["OrderId"]);
                int uId = Convert.ToInt32(reader["UserId"]);
                string coupon = reader["CouponCode"].ToString();
                string address = reader["ShippingAddress"].ToString();
                int price = Convert.ToInt32(reader["OrderPrice"]);
                order= new OrderDetails(oid, uId, coupon, address, price);

            }
            conn.Close();
            if (order.OrderId == 0)
            {
                return null;
            }
            else
            {
                return order;
            }
        }

        public void UpdateOrderDetails(OrderDetails order)
        {
            comm.CommandText = $"Update OrderDetails set UserId ={order.UserId},CouponCode = '{order.CouponCode}',ShippingAddress = '{order.ShippingAddress}',OrderPrice= {order.OrderPrice} where OrderId = "+order.OrderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}