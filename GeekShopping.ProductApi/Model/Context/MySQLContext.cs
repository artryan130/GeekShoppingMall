using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Name 2",
                Price = new decimal(70.8),
                CategoryName = "Category 2",
                ImageURL = "https://www.heidisql.com/download.php/",
                Description = "Description 2",

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Name 5",
                Price = new decimal(120.1),
                CategoryName = "Category 5",
                ImageURL = "https://www.heidisql.com/download.php",
                Description = "Description 5",

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Name 6",
                Price = new decimal(60.88),
                CategoryName = "Category 6",
                ImageURL = "https://www.heidisql.com/download.php",
                Description = "Description 6",

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Name 7",
                Price = new decimal(170.8),
                CategoryName = "Category 7",
                ImageURL = "https://www.heidisql.com/download.php",
                Description = "Description 7",

            });
        }
    }
}
