using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pjt_BookStore.Models;

namespace pjt_BookStore.Controllers
{
    public class LoginController : ApiController
    {
        private LoginImpl repository;

        public LoginController()
        {
            repository = new LoginImpl();
        }
        [HttpPost]
        public IHttpActionResult Post(Login login)
        {
            var data = repository.GetLogin(login);
            return Ok(data);

        }

    }
}
