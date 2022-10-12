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
            comm.CommandText = $"Insert into Books values ({book.CategoryId},'{book.Title}','{book.Author}',{book.ISBN},{book.Year},{book.Price},'{book.Description}',{book.Position},{book.Status} ,'{book.Image}')";
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
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                int position = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string image = reader["Image"].ToString();


                list.Add(new Book(bookId,categoryId,title, author,isbn, year, price, description, position, status, image));
            }
            conn.Close();
            return list;

        }

        Book IBookRepository.GetBookByID(int id)
        {
            Book book = new Book();
            comm.CommandText = "select * from Books where  status =1 and BookId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                book = new Book(bookId, categoryId, title,author, isbn, year, price, description, position, status, image);

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

        List<Book> IBookRepository.GetBookByCatID(int catid)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Books where status =1 and CategoryId = " + catid;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                list.Add( new Book(bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();

              
                return list;
            

        }

        void IBookRepository.UpdateBook(Book book)
        {
            comm.CommandText = $"Update Books set CategoryId={book.CategoryId},Title ='{book.Title}',Author='{book.Author}',ISBN = {book.ISBN},Year = {book.Year},Price= {book.Price},Description='{book.Description}',Position={book.Position},Status={book.Status} ,Image='{book.Image}' where BookId = {book.BookId}";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
          
        }

        List<Book> IBookRepository.GetBookByTitle(string btitle )
        {
            List<Book> list = new List<Book>();
            comm.CommandText = $"select * from Books where Title like '%{btitle}%' and status =1" ;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                list.Add(new Book(bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();


            return list;

        }

        List<Book> IBookRepository.GetBookByAuthor(string bauthor)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = $"select * from Books where Author like '{bauthor}%' and status =1";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                list.Add(new Book(bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();


            return list;

        }

        List<Book> IBookRepository.GetBookByISBN(int bisbn)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = $"select * from Books where status =1 and ISBN = {bisbn}";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                list.Add(new Book(bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();


            return list;

        }

        List<Book> IBookRepository.GetBookByCategory(string bcat)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = $"select * from books where categoryId = (select CategoryId from category where CategoryName like '{bcat}%' and status = 1)";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                list.Add(new Book(bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();


            return list;

        }

        List<Book> IBookRepository.GetBestBooks()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = $"select * from Books where BestBook =1 ";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
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
                list.Add(new Book(bookId, categoryId, title, author, isbn, year, price, description, position, status, image));

            }
            conn.Close();


            return list;
        }

        }
}