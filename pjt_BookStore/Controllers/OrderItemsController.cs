using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pjt_BookStore.Models;

namespace pjt_BookStore.Controllers
{
    public class OrderItemsController : ApiController
    {
        private IOrderItemsRepository repository;
        public OrderItemsController()
        {
            repository = new OrderItemsSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllOrderItems();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/OrderItems/{userid}")]
        public IHttpActionResult Get(int userid)
        {
            var data = repository.GetOrderItemsByID(userid);
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
        [Route("api/OrderItems")]
        public IHttpActionResult Post(int userid,OrderItems items)
        {
            var data = repository.AddOrderItems(userid,items);

            return Ok(data);
        }

        [HttpDelete]
        [Route("api/OrderItems/{userid}/{bookid}")]
        public IHttpActionResult Delete(int userid,int bookid)

        {
            repository.DeleteOrderItems(userid,bookid);
            return Ok();
        }

        //[HttpPut]
        //public IHttpActionResult Put(OrderItems items)
        //{
        //    repository.UpdateOrderItems(items);
        //    return Ok();
        //}
    }
}
