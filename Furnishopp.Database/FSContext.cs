using Furnishopp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnishopp.Database
{
    public class FSContext : DbContext,IDisposable

        
    {
        public FSContext() : base("FurnishoppConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Config> Configurations { get; set; }

        public DbSet<OrderFinal> OrderFinals { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
