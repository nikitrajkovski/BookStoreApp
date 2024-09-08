using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<BookInShoppingCart>? Books { get; set; }
        public int Price { get; set; }
    }
}
