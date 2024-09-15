using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Partner
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string? userId { get; set; }
        public BookStoreUser? Owner { get; set; }
        public virtual IEnumerable<BookInOrder>? BooksInOrder { get; set; }
    }

}
