using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pjt_BookStore.Models;
namespace pjt_BookStore.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSqlImpl();
        }

        [HttpGet]

        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetBookByID(id);
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

    }
}
