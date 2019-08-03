using Microsoft.EntityFrameworkCore;
using ORM_NetCore_EF.Database.Tables;

namespace ORM_NetCore_EF.Database
{
    public class Database : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=orm-sample.db");
        }
    }
}
