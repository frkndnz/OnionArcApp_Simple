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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"), RoleName = "Admin" },
                new Role { Id = Guid.Parse("8F2504E0-4F89-11D3-9A0C-0305E82C3302"), RoleName = "User" }
                );
        }
    }
}
