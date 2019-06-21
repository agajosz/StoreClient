using StoreClient.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreClient.Infrastructure.Services.Abstraction
{
    public interface IOrderService : IService
    {
        Task<bool> AddOrder(Guid clientId, IEnumerable<OrderedProducts> orderedProducts);
        Task<List<Order>> GetOrdersByClient(Guid clientId);
        Task DeleteOrder(Guid orderId);
        Task<List<Order>> GetArchivisedOrders();
    }
}
