using StoreClient.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreClient.Core.Domain
{
    public class Product : Entity<Guid>
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public Enums.Category CategoryId { get; set; }
        public virtual Category Category{get;set;}
    }
}
