using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {

        private readonly string _connectionString;

        public DataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<Order> GetOrders()
        {
            using var ctx = new NorthWindContext(_connectionString);

            return ctx.Orders.ToList();
        }

        public IList<OrderDetails> GetOrderDetails()
        {
            using (var ctx = new NorthWindContext(_connectionString))
                {

               
                    return ctx.OrderDetails
                   .Include(x => x.Order)
                    
                    .ToList();

            ;
            }

        }
        public IList<Category> GetCategories()
        {
            using var ctx = new NorthWindContext(_connectionString);
            return ctx.Categories.ToList();
        }


        public IList<Product> GetProducts()
        {
            using var ctx = new NorthWindContext(_connectionString);
            return ctx.Products
                .Include(x => x.Category)
                .ToList();
        }
    }
}



 