namespace AdminApplication.Models
{
    public class BookInShoppingCart 
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Book? Book { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}