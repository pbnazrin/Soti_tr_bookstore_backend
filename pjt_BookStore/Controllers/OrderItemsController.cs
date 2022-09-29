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
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetOrderItemsByID(id);
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
        public IHttpActionResult Post(OrderItems items)
        {
            var data = repository.AddOrderItems(items);

            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)

        {
            repository.DeleteOrderItems(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(OrderItems items)
        {
            repository.UpdateOrderItems(items);
            return Ok();
        }
    }
}
