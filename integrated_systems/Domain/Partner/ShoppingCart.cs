using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Partner
{
    public class ShoppingCart : BaseEntity
    {
        public string? OwnerId { get; set; }
        public BookStoreUser? Owner { get; set; }
        public virtual ICollection<BookInShoppingCart>? BookInShoppingCart { get; set; } = new List<BookInShoppingCart>();

    }
}
