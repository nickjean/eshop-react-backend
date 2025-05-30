﻿using EShop_React.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop_React.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProduct> WishlistProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
           .HasMany(o => o.Items)
           .WithOne(oi => oi.Order)
           .HasForeignKey(oi => oi.OrderId)
           .OnDelete(DeleteBehavior.Cascade);

            // OrderItem → Product (many-to-1)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // Order → ApplicationUser (many-to-1)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ApplicationUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade if desired

            // Configure Wishlist ↔ Product (many-to-many)
            modelBuilder.Entity<WishlistProduct>()
            .HasKey(wp => new { wp.Id, wp.ProductId });

            modelBuilder.Entity<WishlistProduct>()
                .HasOne(wp => wp.Wishlist)
                .WithMany(w => w.WishlistProducts)
                .HasForeignKey(wp => wp.Id);

            modelBuilder.Entity<WishlistProduct>()
                .HasOne(wp => wp.Product)
                .WithMany(p => p.WishlistProducts)
                .HasForeignKey(wp => wp.ProductId);

            // Configure Wishlist ↔ ApplicationUser (many-to-one)
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.ApplicationUser)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.ApplicationUserId);
        }
    }
}
