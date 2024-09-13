using Domain.Identity;

namespace AdminApplication.Models
{
    public class Order 
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public BookAppUser? Owner { get; set; }
        public IEnumerable<BookInOrder>?BooksInOrder { get; set; }
    }
}