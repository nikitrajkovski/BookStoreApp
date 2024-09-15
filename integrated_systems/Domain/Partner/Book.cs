using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Partner
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? BookImage { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Rating { get; set; }
        public virtual IEnumerable<BookInOrder>? BooksInOrder { get; set; }
        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<Author>? Authors { get; set; } = new List<Author>();
    }
}
