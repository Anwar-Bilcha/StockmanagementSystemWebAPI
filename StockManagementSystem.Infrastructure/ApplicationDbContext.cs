using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DomainModels;
namespace StockManagementSystem.Infrastructure
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("YourConnectionString", options =>
        //            options.MigrationsAssembly("StockManagementSystem.Infrastructure")); // Specify the migrations assembly
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>()
                .HasKey(us => us.Id);
            modelBuilder.Entity<ProductsCategory>()
                .HasKey(pc => pc.categoryId); // Specify the primary key
            modelBuilder.Entity<StockTransaction>()
                .HasKey(pc => pc.transactionId);
            modelBuilder.Entity<Product>()
                .HasKey(pc => pc.productID);
            modelBuilder.Entity<Supplier>()
                .HasKey(pc => pc.supplierId);
           
            // Seed Products table with 4 random records
            modelBuilder.Entity<Product>().Property("productID").ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    productID = -8,
                    productName = "Random Product 1",
                    productDescription = "Description for Random Product 1",
                    Price = 10.99m,
                    productCategory = " Electronics",
                    Quantity = 100,
                    UnitPrice = 10.99m
                },
                new Product
                {
                    productID = -9,
                    productName = "Random Product 1",
                    productDescription = "Description for Random Product 1",
                    Price = 10.99m,
                    productCategory = " Electronics",
                    Quantity = 100,
                    UnitPrice = 10.99m
                },
                new Product
                {
                    productID = -10,
                    productName = "Random Product 1",
                    productDescription = "Description for Random Product 1",
                    Price = 10.99m,
                    productCategory = " Electronics",
                    Quantity = 100,
                    UnitPrice = 10.99m
                },
                new Product
                {
                    productID = -11,
                    productName = "Random Product 1",
                    productDescription = "Description for Random Product 1",
                    Price = 10.99m,
                    productCategory = " Electronics",
                    Quantity = 100,
                    UnitPrice = 10.99m
                }
            );
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsCategory> ProductCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
       
    }
}