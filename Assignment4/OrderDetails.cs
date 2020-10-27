using Npgsql;
using System;
namespace Assignment4
{
    public class OrderDetails
    {

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"OrderId = {OrderId}, ProductId= {ProductId}, UnitPrice = {UnitPrice}, Quantity = {Quantity},Discount= {Discount} ";
        }

    }
}
