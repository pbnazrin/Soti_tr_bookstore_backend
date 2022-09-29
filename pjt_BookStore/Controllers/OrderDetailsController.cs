using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pjt_BookStore.Models;

namespace pjt_BookStore.Controllers
{
    public class OrderDetailsController : ApiController
    {
        private IOrderDetailsRepository repository;
        public OrderDetailsController()
        {
            repository = new OrderDetailsSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllOrderDetails();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetOrderDetailsById(id);
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
        public IHttpActionResult Post(OrderDetails order)
        {
            var data = repository.AddOrderDetails(order);
           
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)

        {
            repository.DeleteOrderDetails(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(OrderDetails order)
        {
            repository.UpdateOrderDetails(order);
            return Ok();
        }
    }
}
