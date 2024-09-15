using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Partner
{
    public class Publisher : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? PublisherImage { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
