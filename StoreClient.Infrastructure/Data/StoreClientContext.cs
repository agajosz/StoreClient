using Microsoft.EntityFrameworkCore;
using StoreClient.Core.Domain;

namespace StoreClient.Infrastructure.Data
{
    public class StoreClientContext : DbContext
    {
        private readonly SqlSettings _settings;

        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderedProducts> OrderedProducts { get; set; }

        public StoreClientContext(DbContextOptions<StoreClientContext> options,
          SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();
                return;
            }

            optionsBuilder.UseSqlServer(_settings.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
