using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreClient.Core.Domain;
using StoreClient.Infrastructure.Model;
using StoreClient.Infrastructure.Services.Abstraction;

namespace StoreClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(
            IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("addClient")]
        public async Task<bool> AddClient([FromBody]ClientModel clientModel)
        {
            return await _clientService.AddClientAsync(clientModel);
        }

        [HttpPost]
        [Route("updateClient")]
        public async Task<bool> UpdateClient([FromBody]ClientModel clientModel)
        {
            return await _clientService.UpdateClient(clientModel);
        }

        [HttpGet]
        [Route("getClients")]
        public async Task<IQueryable<Client>> GetClients()
        {
            return await _clientService.GetClients();
        }

        [HttpGet]
        [Route("searchClient")]
        public async Task<Client> SearchClient(string identity)
        {
            return await _clientService.SearchClient(identity);
        }
    }
}