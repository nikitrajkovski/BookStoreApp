using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AddToCartDTO
    {
        public Guid SelectedProductId { get; set; }
        public string? SelectedBookName { get; set;}
        public int Quantity { get; set; }
    }
}
