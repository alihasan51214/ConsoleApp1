using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
        //ORDER
        public Order Order(int id)
        {
            
            return 
        }
        
        
        public IList<Category> GetOrders()
        {
            using var ctx = new NorthWindContext();
            return ctx.Categories.ToList();
        }
        
        //ORDERDETAILS
        
        //PRODUCTS
        
        //CATEGORY
    }
}