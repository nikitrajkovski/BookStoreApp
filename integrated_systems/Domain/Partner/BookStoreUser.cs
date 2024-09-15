using Microsoft.AspNetCore.Identity;

namespace Domain.Partner
{
    public class BookStoreUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; } = new ShoppingCart();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
