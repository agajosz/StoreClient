using Microsoft.EntityFrameworkCore;

namespace StoreClient.Infrastructure.Data
{
    public class StoreClientContext : DbContext
    {
        private readonly SqlSettings _settings;

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
