using System;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class Order
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

        // public ICollection<OrderDetails> OrderDetails { get; set; }


        public override string ToString()
        {
            return $"OrderId = {OrderId}, CustomerId = {CustomerId}, EmployeeId = {EmployeeId}, OrderDate = {OrderDate}, RequiredDate = {RequiredDate}, ShippedDate = {ShippedDate},                                                           Freight = {Freight}, ShipName = {ShipName}, ShipCity= {ShipCity}, ShipPostalCode = {ShipPostalCode}, ShipCountry = {ShipCountry} ";
        }
         

        }
    }
