using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductManager.Data.Models;

namespace ProductManager.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //on Depoy use ConnectionString from appSettings of .cvv file 
            optionsBuilder.UseSqlite("Filename=ProductsDB.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}
