using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using Domain.Models;
using Service.Interface;
using System.Security.Claims;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IShoppingCartService _shoppingCartService;
        /*        private readonly IAuthorService _authorService;, IAuthorService authorService, IPublisherService publisherService            _authorService = authorService;
            _publisherService = publisherService;
                private readonly IPublisherService _publisherService;*/

        public BooksController(IBookService bookService, IShoppingCartService shoppingCartService)
        {
            _bookService = bookService;
            _shoppingCartService = shoppingCartService;

        }

        // GET: Books
        public IActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Title, Description, Image, Price, Author, Publisher")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                _bookService.CreateNewBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id, Title, Description, Image, Price, Author, Publisher")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException) 
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Delete(Guid? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetDetailsForBook(id);

            BookInShoppingCart bs = new BookInShoppingCart();

            if (book != null)
            {
                bs.BookId = book.Id;
            }
            return View(bs);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.AddToShoppingCartConfirmed(model, userId);

            return View("Index", _bookService.GetAllBooks());
        }
    }
}
