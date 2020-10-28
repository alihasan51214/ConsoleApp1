using System;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Linq;
namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
              .AddJsonFile("config.json")
              .AddEnvironmentVariables()
              .Build();
            
            var dataService = new DataService(config["connectionString"]);
            string connectionString =
       "host=localhost;db=Test;uid=postgres;pwd=bobbystyrer";

         // perhaps we should create a new database connection with the same password? 
            //so all of us can use the same password :P

            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand();

            cmd.Connection = conn;


            /*Order  1st queery */
            Console.WriteLine("1st Queery : select * from orders natural  left join orderdetails natural left join products natural left join categories  where orders.orderid= 10500  ");
            Console.WriteLine();
            cmd.CommandText = "  select * from orders natural  left join orderdetails natural left join products natural left join categories  where orders.orderid= 10500  ";

          


            var reader = cmd.ExecuteReader();
            while(reader.Read())
                    {
                Console.WriteLine($" CategoryId = {reader.GetInt32(0)}, ProductId = {reader.GetInt32(1)}, UnitPrice = {reader.GetInt32(2)}, OrderId = {reader.GetInt32(3)}, CustomerId = {reader.GetString(4)},EmployeeId = {reader.GetInt32(5)}, OrderDate = {reader.GetDate(6)}, RequiredDate = {reader.GetDate(7)}, ShippedDate = {reader.GetDate(8)}" +
                $"  Freight = {reader.GetInt32(9)}, ShipName = {reader.GetString(10)},ShipAddress = {reader.GetString(11)}, ShipCity = {reader.GetString(12)}, ShipPostalCode = {reader.GetString(13)}, ShipCountry = {reader.GetString(14)}, Quantity = {reader.GetInt32(15)}, Discount = {reader.GetInt32(16)}," +
                $" ProductName = {reader.GetString(17)}, SupplerId = {reader.GetInt32(18)}, QuantityPerUnit = {reader.GetString(19)}, UnitInStock = {reader.GetInt32(20)},CategoryName = {reader.GetString(21)}, CategoryDescription = {reader.GetString(22)}");
            }
            reader.Close();
            Console.WriteLine();
        /*2nd Queery */ 
          cmd.CommandText = " select orderid,orderdate,requireddate,shippeddate,shipname from orders where shipname= 'Hanari Carnes' ";
            /* 3rd queery */
            // Note: im Not sure what the difference between 2 and 3 are?
        //    Console.WriteLine();
             //cmd.CommandText = " select orderid from orders where shipname = 'Hanari Carnes' ";
            Console.WriteLine();
            cmd.ExecuteReader();
             
            Console.WriteLine("Queery 2 : select orderid,orderdate,requireddate,shippeddate,shipname from orders where shipname= 'Hanari Carnes'");
            Console.WriteLine();
        
            while (reader.Read())
            {
                
                var order = new Order();
                object resultObject = reader.GetValue(3); //shipname can be null, query fails if it is the case{}
                if (resultObject == DBNull.Value)  
            // the 2nd queery will fail if a column is null, so i've assigned a value to shippedDate if it is null
                {
                    order.ShippedDate = new DateTime(DateTime.Now.Year, 1, 1);

                }
                else
                {
                    Console.WriteLine($"OrderId = {reader.GetInt32(0)}, OrderDate = {reader.GetDate(1)}, RequiredDate = {reader.GetDate(2)}, ShippedDate = {reader.GetDate(3)}, ShipName = {reader.GetString(4)}");
                  
                }

            }
            reader.Close(); // stop the reader and make a new ExeCuteReader to prevent all queeries being run
                            // at the same time. Order and OrderDetails dont have the same colmuns 
                            //Reader needs to be closed, otherwise wrong values will be assigned to the columns in each queery

            //OrderDetails task 4
            Console.WriteLine();
            Console.WriteLine("Queery 4:select orderid,ProductName,  UnitPrice,Quantity  from  orderdetails natural join products  where orderdetails.orderid = 10747");
            cmd.CommandText = " select orderid,ProductName,  UnitPrice,Quantity  from  orderdetails natural join products  where orderdetails.orderid = 10747";
            Console.WriteLine();
            cmd.ExecuteReader();
          
            while (reader.Read())
            {
               
                Console.WriteLine( $"OrderId = {reader.GetInt32(0)}, ProductName = {reader.GetString(1)}, UnitPrice = {reader.GetInt32(2)}, Quantity = {reader.GetInt32(3)} ");
                 
            }
            reader.Close();
            Console.WriteLine();
            Console.WriteLine("Quuery 5: select ProductId, orderdate, UnitPrice, Quantity from orderdetails natural join orders where orders.orderid = 10747");
            //OrderDetails task 5
            Console.WriteLine();
            cmd.CommandText = "select ProductId, orderdate,UnitPrice,Quantity from  orderdetails natural join orders where orders.orderid = 10747 ";
              cmd.ExecuteReader();
            while (reader.Read())
            {  Console.WriteLine($"ProductId = {reader.GetInt32(0)}, OrderDate = {reader.GetDate(1)}, UnitPrice = {reader.GetInt32(2)}, Quantity = {reader.GetInt32(3)} ");

            }
        }
    }
    
}

