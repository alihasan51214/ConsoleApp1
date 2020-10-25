using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
    
        
        public IList<Order> GetOrders()
        {
            using var ctx = new NorthWindContext();
            return ctx.Orders.ToList();
        }

        public IList<OrderDetails> GetOrderDetails()
        {
            using var ctx = new NorthWindContext();
            return ctx.OrderDetails.ToList();
        }
    }
}