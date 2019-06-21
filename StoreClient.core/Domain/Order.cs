using StoreClient.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreClient.Core.Domain
{
    public class Order : Entity<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderedProducts> OrderedProducts { get; set; } = new List<OrderedProducts>();
    }
}
