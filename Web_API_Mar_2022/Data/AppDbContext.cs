using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.Models;

namespace Web_API_Mar_2022.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op){}

        public DbSet<Order> Orders { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<OrderProduts> OrderProduts { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Boiled water", Price = 9.99}
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Name = "Mark's order", Date = DateTime.Now }
            );

            modelBuilder.Entity<OrderProduts>().HasData(
                new OrderProduts { Id = 1, OrderId = 1, ProductId = 1}
            );
        }
    }
}
