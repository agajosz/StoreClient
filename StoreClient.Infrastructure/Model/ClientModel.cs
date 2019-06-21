using StoreClient.Core.Domain;
using System;
using System.Collections.Generic;

namespace StoreClient.Infrastructure.Model
{
    public class ClientModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
