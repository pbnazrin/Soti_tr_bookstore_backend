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
        List<OrderItems> GetOrderItemsByID(int id);
        OrderItems AddOrderItems(int userid,OrderItems items);
        void DeleteOrderItems(int userid,int bookid);
        //void UpdateOrderItems(OrderItems items);
    }
}
