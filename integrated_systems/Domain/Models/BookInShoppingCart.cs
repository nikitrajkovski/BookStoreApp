namespace Domain.Models
{
    public class BookInShoppingCart : BaseEntity
    {
        public Guid BookId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Book? Book { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}