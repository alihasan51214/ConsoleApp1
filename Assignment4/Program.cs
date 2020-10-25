using System;
using Npgsql;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
            "host=localhost;db=Test;uid=postgres;pwd=bobbystyrer"; 

            // perhaps we should create a new database connection with the same password ?
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "select orderid, orderDate from orders";

            var reader = cmd.ExecuteReader();  

            while (reader.Read())
            {
                var order = new Order
                {
                    Id = reader.GetInt32(0),
                   OrderDate = reader.GetDateTime(1)
                };
                

                Console.WriteLine(order);
                

                //Console.WriteLine($"Id={reader.GetInt32(0)}, Name={reader.GetString(1)}");
            }
        }
    }
}

