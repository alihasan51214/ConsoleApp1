using System;
using Npgsql;


namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //     Order.OrderByShippingName();
            // Order.CreateCommand();
            string connectionString =
       "host=localhost;db=Test;uid=postgres;pwd=bobbystyrer";

            // perhaps we should create a new database connection with the same password? 
            //so all of us can use the same password :P

            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand();

            cmd.Connection = conn;


            /*Order Task 2nd queery */
            cmd.CommandText = " select orderid,orderdate,requireddate,shippeddate,shipname from orders where shipname= 'Hanari Carnes' ";

            /*Order Task 3rd queery */
            cmd.CommandText = " select orderid,orderdate,requireddate,shippeddate,shipname from orders";

    
            var reader = cmd.ExecuteReader();

             
            while (reader.Read())
            {
                
                var order = new Order();
                object resultObject = reader.GetValue(3);
                if (resultObject == DBNull.Value)  
            // the 2nd queery will fail if a column is null, so i've assigned a value to shippedDate if it is null
                {
                    order.ShippedDate = new DateTime(DateTime.Now.Year, 1, 1);

                }
                else
                {
                    Console.WriteLine($"OrderId={reader.GetInt32(0)}, OrderDate={reader.GetDate(1)},RequiredDate={reader.GetDate(2)},ShippedDate={reader.GetDate(3)},ShipName={reader.GetString(4)}");
                  
                }

               

              
            }
            reader.Close(); // stop the reader and make a new ExeCuteReader to prevent all queeries being run
            // at the same time. Order and OrderDetails dont have the same colmuns 
            //so you cant run all ExecuteReader() at once

           //OrderDetails task 4
            
            cmd.CommandText = " select orderid,ProductId,UnitPrice,Quantity,Discount from orderdetails where orderid = 10747";
            var reader2 = cmd.ExecuteReader();
          
            while (reader2.Read())
            {
                 
                var orderdetails = new OrderDetails();
                Console.WriteLine($"OrderId={reader.GetInt32(0)}, ProductId={reader.GetInt32(1)},UnitPrice={reader.GetInt32(2)},Quantity={reader.GetInt32(3)},Discount={reader.GetInt32(4)}");

            }
        }
    }
    
}

