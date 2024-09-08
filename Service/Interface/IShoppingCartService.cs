using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteBookFromShoppingCart(string userId, Guid bookId);
        bool order(string userId);
        bool AddToShoppingCartConfirmed(BookInShoppingCart model, string userId);
    }
}
