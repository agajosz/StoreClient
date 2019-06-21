using StoreClient.Core.Domain.Base;
using System;

namespace StoreClient.Core.Domain
{
    public class OrderedProducts
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}
