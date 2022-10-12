using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjt_BookStore.Models
{
    internal interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBookByID(int id);
        Book AddBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);

        List<Book> GetBookByCatID(int catid);

        List<Book> GetBookByTitle(string btitle);
        List<Book> GetBookByAuthor(string bauthor);
        List<Book> GetBookByISBN(int bisbn);
        List<Book> GetBookByCategory(string bcat);

        List<Book> GetBestBooks();



    }
}
