using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment4
{
    public class NorthWindContext : DbContext
    {
        private readonly string _connectionString;

        public NorthWindContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql(_connectionString); 

        //    optionsBuilder.UseNpgsql("host=localhost;db=NorthWind;uid=postgres;pwd=bobbystyrer");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");
            
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.CustomerId).HasColumnName("customerid");
            modelBuilder.Entity<Order>().Property(x => x.EmployeeId).HasColumnName("employeeid");
            modelBuilder.Entity<Order>().Property(x => x.OrderDate).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.RequiredDate).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.ShippedDate).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
            modelBuilder.Entity<Order>().Property(x => x.ShipPostalCode).HasColumnName("shipostalcode");
            modelBuilder.Entity<Order>().Property(x => x.ShipCountry).HasColumnName("shipcountry");

            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<Order>().Property(x => x.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<Product>().Property(x => x.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.ProductId).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.SupplierId).HasColumnName("supplierid");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
        }
    }
}