using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Data;
using StoreClient.Infrastructure.Repositories.Base;

namespace StoreClient.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreClientContext context) : base(context)
        {

        }
    }
}
