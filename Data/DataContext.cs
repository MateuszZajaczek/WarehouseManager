using Microsoft.EntityFrameworkCore;
using WarehouseManager.Entities;

namespace WarehouseManager.Data;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }

