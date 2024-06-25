using Microsoft.EntityFrameworkCore;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Data
{
    public class DataContext: DbContext
    {
        //private readonly DbContextOptions<DataContext> _options;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //_options = options;
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItens { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
    }
}