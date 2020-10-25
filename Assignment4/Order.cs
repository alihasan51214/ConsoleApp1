using System;
using Npgsql;


using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public  class Order
    {


        public int OrderId { get; set; }
        public string CustomerId { get; set; }

        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }


        public override string ToString()
        {
            return $"OrderId = {OrderId}, CustomerId = {CustomerId}, EmployeeId = {EmployeeId}, OrderDate = {OrderDate}, RequiredDate = {RequiredDate}, ShippedDate = {ShippedDate},                                                           Freight = {Freight}, ShipName = {ShipName}, ShipCity= {ShipCity}, ShipPostalCode = {ShipPostalCode}, ShipCountry = {ShipCountry}";
        }

        public  static void CreateCommand()
        {

            string connectionString =
          "host=localhost;db=Test;uid=postgres;pwd=bobbystyrer";

            // perhaps we should create a new database connection with the same password? 
            //so all of us can use the same password :P

            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "select * from orders where orderid= 10500 ";

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                
                    var order = new Order ()

                {
                    OrderId = reader.GetInt32(0),
                    CustomerId = reader.GetString(1),
                    EmployeeId = reader.GetInt32(2),
                    OrderDate = reader.GetDateTime(3),
                    RequiredDate = reader.GetDateTime(4),
                   ShippedDate = reader.GetDateTime(5),
                    Freight = reader.GetInt32(6),
                    ShipName = reader.GetString(7),
                    ShipCity = reader.GetString(8),
                    ShipPostalCode = reader.GetString(9),
                    ShipCountry = reader.GetString(10)

                };

                /* using var ctx = new NorthWindContext();

              foreach (var product in ctx.Products.Include(x => x.Category)) //for creating foreign keys, incomplete
               {
                   Console.WriteLine(product);
               }   
            */
                 

                Console.WriteLine(order);
 
            }
        }


    }
}