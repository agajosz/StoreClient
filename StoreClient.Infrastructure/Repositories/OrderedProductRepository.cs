using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Data;
using StoreClient.Infrastructure.Repositories.Base;

namespace StoreClient.Infrastructure.Repositories
{
    public class OrderedProductRepository : BaseRepository<OrderedProducts>, IOrderedProductRepository
    {
        public OrderedProductRepository(StoreClientContext context) : base(context)
        {

        }
    }
}
