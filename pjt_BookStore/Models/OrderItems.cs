using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class OrderItems
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int BookPrice { get; set; }
     

        public OrderItems()
        {

        }

        public OrderItems(int itemId,int orderId,int bookId,int bookPrice)
        {
            ItemId = itemId;
            OrderId = orderId;
            BookId = bookId;
            BookPrice = bookPrice;
          

        }
    }
}