using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Domain.Models
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public virtual IEnumerable<BookInOrder>? BooksInOrder { get; set; }
        public virtual ICollection<BookInShoppingCart>? BookInShoppingCart {  get; set; }

    }
}