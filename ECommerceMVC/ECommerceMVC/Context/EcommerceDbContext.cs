using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Context;

public class EcommerceDbContext : DbContext
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


    public DbSet<Complaint> Complaint { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<AttributeValues> AttributeValues { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Customer> Customer { get; set; }
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

}
