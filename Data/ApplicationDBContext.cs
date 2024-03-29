using System;
using FanCentral2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FanCentral2.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GuestOrder> GuestOrders { get; set; }
        public DbSet<Payment> Payments {get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<GuestOrder>().ToTable("GuestOrder");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<OrderedProduct>().ToTable("OrderedProduct");

            //IDK
            base.OnModelCreating(modelBuilder);
        }
    }
}