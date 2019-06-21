using Microsoft.EntityFrameworkCore;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StoreClient.Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly StoreClientContext _context;
        private DbSet<T> _table = null;

        public BaseRepository(StoreClientContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
