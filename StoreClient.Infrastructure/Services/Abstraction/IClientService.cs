using StoreClient.Core.Domain;
using StoreClient.Infrastructure.Model;
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
        Task<bool> AddClientAsync(ClientModel client);
        Task<bool> UpdateClient(ClientModel client);
        Task<Client> SearchClient(string identity);
    }
}
