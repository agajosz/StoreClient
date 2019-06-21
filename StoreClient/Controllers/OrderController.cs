using Microsoft.AspNetCore.Mvc;
using StoreClient.Core.Domain;
using StoreClient.Infrastructure.Model;
using StoreClient.Infrastructure.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(
            IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("addOrder")]
        public async Task<bool> AddOrder([FromBody]OrderApiModel orderModel)
        {
            return await _orderService.AddOrder(orderModel.ClientId, orderModel.OrderedProducts);
        }

        [HttpGet]
        [Route("getOrdersByClient")]
        public async Task<List<Order>> GetOrderByClientId(Guid clientId)
        {
            return await _orderService.GetOrdersByClient(clientId);
        }

        [HttpPost]
        [Route("deleteOrder")]
        public async Task DeleteOrder(Guid orderId)
        {
            await _orderService.DeleteOrder(orderId);
        }
    }
}
