using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Data;
using StoreClient.Infrastructure.Repositories.Base;

namespace StoreClient.Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(StoreClientContext context) : base(context)
        {
        }
    }
}
