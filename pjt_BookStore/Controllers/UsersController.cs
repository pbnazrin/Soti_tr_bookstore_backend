using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pjt_BookStore.Models;

namespace pjt_BookStore.Controllers
{
    public class UsersController : ApiController
    {
        private IUserRepository repository;
        public UsersController()
        {
            repository = new UsersSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllUsers();
            return Ok(data);
        }
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetUsersById(id);
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
        //[Route("Register")]
        public IHttpActionResult Register([FromBody] Users users)
        {
            var data = repository.AddUser(users);
            return Ok(data);
            
        }

        //[HttpPost]
        //[Route("Login/{users}")]
        //public IHttpActionResult Login([FromBody] Users users)
        //{
        //    var data = repository.AddUser(users);
        //    return Ok(data);

        //}

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteUsers(id);
            return Ok();

        }
        [HttpPut]
        public IHttpActionResult Put(Users users)
        {
            repository.UpdateUsers(users);
            return Ok();

        }

        [HttpPost]
        public IHttpActionResult Post(int userid,int bookid)
        {
             repository.AddToWishList(userid, bookid);
            return Ok();

        }

        [HttpGet]
        public IHttpActionResult GetWishList(int userid)
        {
            var data = repository.ViewWishList(userid);
            return Ok();
        }




    }
}
