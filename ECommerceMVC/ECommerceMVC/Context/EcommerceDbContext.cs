﻿using ECommerceMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Context;

public class EcommerceDbContext : IdentityDbContext<Customer, IdentityRole<int>,int>
{
    public EcommerceDbContext() : base()
    {

    }
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        //optionsBuilder.UseSqlServer("Server=MAHMOUD\\SQLEXPRESS; Database=E-CommerceDB; Trusted_Connection=true; Encrypt=false; MultipleActiveResultSets=True;"); 
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=SQL8003.site4now.net;Initial Catalog=db_a9837b_ecommercedb;User Id=db_a9837b_ecommercedb_admin;Password=NGMM123456");
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole<int>> Roles = new List<IdentityRole<int>>()
        {
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },

            new IdentityRole<int>
            {
                Id = 2,
                Name = "Member",
                NormalizedName = "Member".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole<int>
            {
                Id = 3,
                Name = "Vendor",
                NormalizedName = "Vendor".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };

        //builder.Entity<IdentityRole<int>>().HasData(Roles);
    }

    #region Tables
    public DbSet<Complaint> Complaint { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<AttributeValues> AttributeValues { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Country> Country { get; set; }   
    public DbSet<Discount> Discount { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<PaymentMethod> PaymentMethod { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductAttribute> ProductAttribute { get; set; }
    public DbSet<ProductAttributeValues> ProductAttributeValues { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<ProductItem> ProductItem { get; set; }
    public DbSet<ProductType> ProductType { get; set; }
    public DbSet<ProductTypeAttribute> ProductTypeAttribute { get; set; }
    public DbSet<ShoppingBag> ShoppingBag { get; set; }
    public DbSet<ShoppingBagItem> ShoppingBagItem { get; set; }
    public DbSet<ECommerceMVC.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    public DbSet<ECommerceMVC.ViewModels.EditUserViewModel> EditUserViewModel { get; set; } = default!;
    public DbSet<ECommerceMVC.ViewModels.OrderDetailsViewModel> OrderDetailsViewModel { get; set; } = default!;
    public DbSet<ECommerceMVC.ViewModels.ShoppingBagViewModel> ShoppingBagViewModel { get; set; } = default!;
    public DbSet<ProductReview> ProductReviews { get; set; }

    #endregion
}
