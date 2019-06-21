using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Data;
using StoreClient.Infrastructure.Repositories.Base;

namespace StoreClient.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreClientContext context) : base(context)
        {

        }
    }
}
