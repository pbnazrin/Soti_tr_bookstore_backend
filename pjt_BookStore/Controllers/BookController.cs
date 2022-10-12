using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using pjt_BookStore.Models;
namespace pjt_BookStore.Controllers
{
    [EnableCors(origins:"http://localhost:4200",headers:"*",methods:"*")]
    //[Route("api/book")]
    public class BookController : ApiController
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSqlImpl();
        }

        [HttpGet,Route("api/book")]
      

        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }


        [HttpGet, Route("api/book/GetBookById/{bookId}")]
        public IHttpActionResult GetBookById(int bookId)
        {
            var data = repository.GetBookByID(bookId);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet, Route("api/book/GetBookByTitle/{title}")]
        public IHttpActionResult GetBookByTitle(string title)
        {
            var data = repository.GetBookByTitle(title);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet, Route("api/book/GetBookByAuthor/{author}")]
        //http://localhost:50073/api/book/GetBookByAuthor?author=sudha
        //[HttpGet]
        public IHttpActionResult GetBookByAuthor(string author)
        {
            var data = repository.GetBookByAuthor(author);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet, Route("api/book/GetBookByisbn/{isbn}")]
        public IHttpActionResult GetBookByISBN(int isbn)
        {
            var data = repository.GetBookByISBN(isbn);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet, Route("api/book/GetBookByCategory/{bcat}")]
        public IHttpActionResult GetBookByCategory(string bcat)
        {
            var data = repository.GetBookByCategory(bcat);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            var data1 = repository.GetAllBook();
            return Ok(data1);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        
        {
            repository.DeleteBook(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Book book)
        {
            repository.UpdateBook(book);
            return Ok();
        }

        [HttpGet, Route("api/book/GetBookByCatId/{catId}")]
        public IHttpActionResult GetBookByCatId(int catId)
        {
            var data = repository.GetBookByCatID(catId);
            return Ok(data);

        }

        [HttpGet,Route("api/book/GetBestBooks")]
        //http://localhost:50073/api/book/GetBestBooks
        public IHttpActionResult GetBestBooks()
        {
            var data = repository.GetBestBooks();
            return Ok(data);
        }


    }
}
