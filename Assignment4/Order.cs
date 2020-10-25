using System;
using Npgsql;


namespace Assignment4
{
    public  class Order
    {


        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }


        public override string ToString()
        {
            return $"Id = {Id}, OrderDate = {OrderDate}";
        }

        public   void CreateCommand()
        {
            using var cmd = new NpgsqlCommand();
     
           

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

            }
        }


    }
}