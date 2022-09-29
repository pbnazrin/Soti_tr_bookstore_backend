using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
        public string ShippingAddress { get; set; }
        public int OrderPrice { get; set; }

        public OrderDetails()
        {

        }
        public OrderDetails(int id,int uid,string coupon,string address,int price)
        {
            OrderId = id;

            UserId = uid;

            CouponCode = coupon;

            ShippingAddress = address;

            OrderPrice = price;



        }
    }


}