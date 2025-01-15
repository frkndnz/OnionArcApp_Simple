using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = new Guid(),
                    Name = "Pen",
                    Value = 10,
                    Quantity = 100
                },
                new Product()
                {
                    Id = new Guid(),
                    Name = "Book",
                    Value = 30,
                    Quantity = 500
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
