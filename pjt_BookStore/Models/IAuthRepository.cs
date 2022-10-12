using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjt_BookStore.Models
{
    internal interface IAuthRepository
    {

        List<Book> GetAllBook();
        Book GetBookByID(int id);
        Book AddUser(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);

        List<Book> GetBookByCatID(int catid);
    }
}
