using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Extensions.Configuration;

namespace DL
{
   public class StoreDBContext : DbContext
    {
        // IConfiguration Config;
        public StoreDBContext() : base()
        {
        }
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=fanny.db.elephantsql.com;Username=thaejseo;Password=XO3kXem6JgnL3upkObFs8KzmxHOdfgwz;Database=thaejseo");
            }
        }

        public DbSet<Customer> Customers {get; set; }
        public DbSet<Inventory> Inventories {get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardItem> CardItems { get; set; }



    }
}
