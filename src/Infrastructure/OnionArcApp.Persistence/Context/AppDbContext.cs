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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pen",
                    Value = 10,
                    Quantity = 100
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Book",
                    Value = 30,
                    Quantity = 500
                }
                );

        }
    }
}
