using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace pjt_BookStore.Models
{
    public class BookSqlImpl : IBookRepository
    {
        SqlCommand comm;
        SqlConnection conn;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDb"].ConnectionString);
            comm = new SqlCommand();
        }
        Book IBookRepository.AddBook(Book book)
        {
            comm.CommandText = $"Insert into Books values ({book.CategoryId},'{book.Title}',{book.ISBN},{book.Year},{book.Price},'{book.Description}',{book.Position},{book.Status} ,'{book.Image}')";
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

        void IBookRepository.DeleteBook(int id)
        {
            comm.CommandText = "Delete from Books where BookId=" + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        List<Book> IBookRepository.GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Books";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string image = reader["Image"].ToString();


                list.Add(new Book(bookId,categoryId,title, isbn, year, price, description, position, status, image));
            }
            conn.Close();
            return list;

        }

        Book IBookRepository.GetBookByID(int id)
        {
            Book book = new Book();
            comm.CommandText = "select * from Books where BookId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string image = reader["Image"].ToString();
                book = new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image);

            }
            conn.Close();
            if (book.BookId == 0)
            {
                return null;
            }
            else
            {
                return book;
            }
            
        }

        void IBookRepository.UpdateBook(Book book)
        {
            comm.CommandText = $"Update Books set CategoryId={book.CategoryId},Title ='{book.Title}',ISBN = {book.ISBN},Year = {book.Year},Price= {book.Price},Description='{book.Description}',Position={book.Position},Status={book.Status} ,Image='{book.Image}' where BookId = {book.BookId}";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
          
        }
    }
}