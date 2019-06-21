using StoreClient.Core.Domain;
using StoreClient.Core.Repositories;
using StoreClient.Infrastructure.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreClient.Infrastructure.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> AddOrder(Guid clientId, IEnumerable<OrderedProducts> orderedProducts)
        {
            try
            {
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    ClientId = clientId,
                    OrderedProducts = orderedProducts.ToList()
                };

                await _orderRepository.Add(order);

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var order = _orderRepository
                .GetAll()
                .First(o => o.Id == orderId && o.IsDeleted == false);

            order.IsDeleted = true;

            await _orderRepository.Update(order);
        }

        public async Task<List<Order>> GetOrdersByClient(Guid clientId)
        {
            var clientOrders = _orderRepository
                .GetAll()
                .Where(o => o.ClientId == clientId && o.IsDeleted == false)
                .ToList();

            return await Task.FromResult(clientOrders);
        }

        public async Task<List<Order>> GetArchivisedOrders() =>
            await Task.FromResult(_orderRepository
                .GetAll()
                .Where(o => o.IsDeleted == true)
                .ToList());
    }
}
