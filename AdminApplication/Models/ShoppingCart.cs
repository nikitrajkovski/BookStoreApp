using Domain.Identity;

namespace AdminApplication.Models
{
    public class ShoppingCart 
    {
        public Guid Id { get; set; }
        public string? OwnerId { get; set; }
        public BookAppUser? Owner { get; set; }
        public virtual ICollection<BookInShoppingCart>? BookInShoppingCarts { get; set; }
    }
}