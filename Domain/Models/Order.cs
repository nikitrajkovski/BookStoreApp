using Domain.Identity;

namespace Domain.Models
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public BookAppUser Owner { get; set; }
        public IEnumerable<BookInOrder> BooksInOrder { get; set; }
    }
}