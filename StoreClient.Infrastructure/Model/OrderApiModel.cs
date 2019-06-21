using StoreClient.Core.Domain;
using System;
using System.Collections.Generic;

namespace StoreClient.Infrastructure.Model
{
    public class OrderApiModel
    {
        public Guid ClientId { get; set; }
        public IEnumerable<OrderedProducts> OrderedProducts { get; set; }
    }
}
