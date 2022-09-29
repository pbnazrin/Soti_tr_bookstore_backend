using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjt_BookStore.Models
{
    internal interface IOrderItemsRepository
    {
        List<OrderItems> GetAllOrderItems();
        OrderItems GetOrderItemsByID(int id);
        OrderItems AddOrderItems(OrderItems items);
        void DeleteOrderItems(int id);
        void UpdateOrderItems(OrderItems items);
    }
}
