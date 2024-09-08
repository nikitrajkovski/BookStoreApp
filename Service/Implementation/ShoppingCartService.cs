using Domain.DTO;
using Domain.Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<BookInOrder> _bookInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<BookInShoppingCart> bookInShoppingCartRepository, IRepository<Order> orderRepository, IRepository<BookInOrder> bookInOrderRepository, IUserRepository userRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _orderRepository = orderRepository;
            _bookInOrderRepository = bookInOrderRepository;
            _userRepository = userRepository;
        }

        public bool AddToShoppingCartConfirmed(BookInShoppingCart model, string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser.ShoppingCart;
            if (userShoppingCart.BookInShoppingCarts == null)
            {
                userShoppingCart.BookInShoppingCarts = new List<BookInShoppingCart>();
            }

            userShoppingCart.BookInShoppingCarts.Add(model);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public bool deleteBookFromShoppingCart(string userId, Guid bookId)
        {
            if (bookId != null)
            {
                var loggedInUser = _userRepository.Get(userId);
                var userShoppingCart = loggedInUser.ShoppingCart;
                var book = userShoppingCart.BookInShoppingCarts.Where(z=>z.BookId == bookId).FirstOrDefault();
                userShoppingCart.BookInShoppingCarts.Remove(book);
                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
            var allBooks = userShoppingCart?.BookInShoppingCarts?.ToList();

            var totalPrice = allBooks.Select(z=>(z.Book.Price * z.Quantity)).Sum();

            ShoppingCartDto dto = new ShoppingCartDto
            {
                Books = allBooks,
                Price = totalPrice,
            };

            return dto;
        }

        public bool order(string userId)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);
                var userShoppingCart = loggedInUser.ShoppingCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Owner = loggedInUser
                };

                _orderRepository.Insert(order);
                List<BookInOrder> bookInOrder = new List<BookInOrder>();

                var list = userShoppingCart.BookInShoppingCarts?.Select(x=> new BookInOrder
                {
                    Id = Guid.NewGuid(),
                    BookId = x.Book.Id,
                    Book = x.Book,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = x.Quantity
                }).ToList();

                StringBuilder sb = new StringBuilder();
                var totalPrice = 0;

                sb.AppendLine("Вашата нарачка е готова. Нарачката содржи: ");

                for (int i=0; i<=list.Count(); i++)
                {
                    var currentItem = list[i];
                    totalPrice += currentItem.Quantity * currentItem.Book.Price;
                    sb.AppendLine(i+1.ToString() + ". " + currentItem.Book.Title + " со " + currentItem.Quantity + "копии, по цена од " + currentItem.Book.Price + "ден.");
                }

                sb.AppendLine("Вашата нарачка изнесува: " + totalPrice.ToString() + "ден.");
                //message.Content = sb.ToString();

                bookInOrder.AddRange(list);

                foreach (var book in bookInOrder)
                {
                    _bookInOrderRepository.Insert(book);
                }

                loggedInUser.ShoppingCart.BookInShoppingCarts.Clear();
                _userRepository.Update(loggedInUser);
                return true;
            }
            return false;
        }
    }
}
