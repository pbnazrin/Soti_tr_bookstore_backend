using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pjt_BookStore.Models;

namespace pjt_BookStore.Controllers
{
   
    public class CategoryController : ApiController
    {
        private ICategoryReference repository;

        public CategoryController()
        {
            repository = new CategoryImpl();

        }
        [HttpGet, Route("api/category/{catId}")]
        public IHttpActionResult Get(int catId)
        {
            var data = repository.GetCategoryByID(catId);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpGet]
        
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategory();
            return Ok(data);
        }

        

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            var data1 = repository.GetAllCategory();
            return Ok(data1);
        }

        [HttpDelete,Route("api/Category/{catId}")]
        public IHttpActionResult Delete(int catId)
        {
            repository.DeleteCategory(catId);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Category category)
        {
            repository.UpdateCategory(category);
            return Ok();

        }
       
    }
}
