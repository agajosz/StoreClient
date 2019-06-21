using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Infrastructure.Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Task<bool> AddClient(ClientModel clientModel)
        {
            _clientRepository.Add(new Client
            {
                Id = Guid.NewGuid(),

            });
        }

        public async Task<IQueryable<Client>> GetClients()
        {
            var clientsList = _clientRepository
                .GetAll()
                .Where(c => c.IsDeleted == false);

            return await Task.FromResult(clientsList);
        }

        public async Task<Client> SearchClient(string identity)
        {
            return await Task.FromResult(_clientRepository
               .GetAll()
               .FirstOrDefault(c => c.IsDeleted == false &&
               (c.Login == identity || c.Name == identity || c.Email == identity)));
        }

        public Task<bool> UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
