using Microsoft.EntityFrameworkCore;
using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Model;
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

        public async Task<bool> AddClientAsync(ClientModel clientModel)
        {
            try
            {
                await _clientRepository.Add(new Client
                {
                    Id = Guid.NewGuid(),
                    Login = clientModel.Login,
                    Email = clientModel.Email,
                    Name = clientModel.Name,
                    Password = clientModel.Password,
                    PhoneNumber = clientModel.PhoneNumber,
                    Surname = clientModel.Surname
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

        }

        public async Task<bool> UpdateClient(ClientModel clientModel)
        {
            var client = await _clientRepository.GetById(clientModel.Id);

            client.Login = clientModel.Login;
            client.Name = clientModel.Name;
            client.Surname = clientModel.Surname;
            client.Password = clientModel.Password;
            client.PhoneNumber = clientModel.PhoneNumber;
            client.Email = clientModel.Email;

            await _clientRepository.Update(client);

            return true;
        }

        public async Task<IQueryable<Client>> GetClients()
        {
            var clientsList = _clientRepository
                .GetAll()
                .Include(c => c.Orders).ThenInclude(o => o.OrderedProducts)
                .Where(c => c.IsDeleted == false)
                .OrderByDescending(c => c.CreationDateTime);

            return await Task.FromResult(clientsList);
        }

        public async Task<Client> SearchClient(string identity)
        {
            return await Task.FromResult(_clientRepository
               .GetAll()
               .FirstOrDefault(c => c.IsDeleted == false &&
               (c.Login == identity || c.Name == identity || c.Email == identity)));
        }
    }
}
