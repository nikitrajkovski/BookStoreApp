using Domain.Identity;

namespace Domain.Models
{
    public class ShoppingCart : BaseEntity
    {
        public string? OwnerId { get; set; }
        public BookAppUser? Owner { get; set; }
        public virtual ICollection<BookInShoppingCart>? BookInShoppingCarts { get; set; }
    }
}