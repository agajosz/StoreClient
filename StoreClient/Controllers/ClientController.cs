using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreClient.Core.Domain;
using StoreClient.Infrastructure.Services.Abstraction;

namespace StoreClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IOrderService _orderService;
        public ClientController(
            IClientService clientService,
            IOrderService orderService)
        {
            _clientService = clientService;
            _orderService = orderService;
        }
        [HttpGet]
        [Route("addClient")]
        public async Task<bool> AddClient(Client client)
        {
            return await _clientService.AddClient(client);
        }
    }
}