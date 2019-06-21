using System.Linq;
using System.Threading.Tasks;

namespace StoreClient.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<T> GetById(object id);
    }
}
