using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ORM_NetCore_EF.Database.Tables;

namespace ORM_NetCore_EF.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseFile = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\orm-sample.db");
            Console.WriteLine($"Sqlite database file: [{databaseFile}]");
            optionsBuilder.UseSqlite($"Data Source={databaseFile}");
        }
    }
}
