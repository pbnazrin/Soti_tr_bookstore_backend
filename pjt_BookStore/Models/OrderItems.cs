using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class OrderItems
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }

        public int Status { get; set; }
        public string Image { get; set; }

        public OrderItems()
        {

        }
        public OrderItems(int orderId,int userId,int bookId, int categoryId, string title, string author, int isbn, int year, float price,
string description, int position, int status, string image)
        {
            CartId = orderId;
            UserId = userId;
            BookId = bookId;
            CategoryId = categoryId;
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = description;
            Position = position;
            Status = status;
            Image = image;
        }
    }
}