using StoreClient.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Infrastructure.Services.Abstraction
{
    public interface IClientService : IService
    {
        Task<IQueryable<Client>> GetClients();
        Task<bool> AddClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<Client> SearchClient(string identity);
    }
}
