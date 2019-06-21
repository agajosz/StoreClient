using StoreClient.Core.Domain.Base;

namespace StoreClient.Core.Domain
{
    public class Category : Entity<Enums.Category>
    {
        public string CategoryName { get; set; }
    }
}
