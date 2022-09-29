using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public WishList()
        {

        }
        public WishList(int bid, int uid, int wishListId)
        {
            WishListId = wishListId;
            BookId = bid;
            UserId = uid;
        }
    }
}