using System.Net;

namespace Domain.Models
{
    public class BookInOrder : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
    }
}