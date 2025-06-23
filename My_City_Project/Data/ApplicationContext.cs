using Microsoft.EntityFrameworkCore;
using My_City_Project.Model.Entities;

namespace My_City_Project.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Places> Places { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Reseller> Resellers { get; set; }
        public DbSet<User> Users { get; set; }

        public static void Initialize(ApplicationContext context)
        {
            context.Database.Migrate();  
        }
    }
}
