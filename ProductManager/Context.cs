using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

namespace ProductManager
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //on Depoy use ConnectionString from appSettings of .cvv file 
            optionsBuilder.UseSqlite("Filename=ProductsDB.db");
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}
