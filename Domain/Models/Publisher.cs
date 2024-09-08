namespace Domain.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}