using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjt_BookStore.Models
{
    internal interface IOrderDetailsRepository
    {
        List<OrderDetails> GetAllOrderDetails();
        OrderDetails GetOrderDetailsById(int id);
        OrderDetails AddOrderDetails(OrderDetails order);
        void DeleteOrderDetails(int id);
        void UpdateOrderDetails(OrderDetails order);
    }
}
