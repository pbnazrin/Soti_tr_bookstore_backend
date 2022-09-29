using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public string Title{ get; set; }
        public int ISBN { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }

        public int Status { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }
        public Book(int bookId , int categoryId,string title,int isbn,int year,float price,
string description,int position,int status ,string image)
        {
            BookId = bookId;
            CategoryId = categoryId;
            Title = title;
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