using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Partner;
using Repository;
using Service.Interface;
using Service.Implementation;
using System.Security.Claims;

namespace BookStore.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerBookService bookService;
        private readonly IPartnerPublisherService publisherService;
        private readonly IPartnerAuthorService authorService;
        public PartnerController(IPartnerBookService _booService,
            IPartnerPublisherService _publisherService,
            IPartnerAuthorService _authorService)
        {
            this.publisherService = _publisherService;
            this.bookService = _booService;
            this.authorService = _authorService;
        }
        // GET: BookController
        public ActionResult Index()
        {
            return View(bookService.GetAllBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(bookService.GetDetailsForBook(id));

        }
        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.Publishers = publisherService.GetAllPublishers();
            ViewBag.Authors = authorService.GetAllAuthors();
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Title,BookImage,Price,Rating,PublisherId")] Book book, Guid[] AuthorIds)
        {

            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                bookService.CreateNewBook(book);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Publishers = publisherService.GetAllPublishers();
            ViewBag.Authors = authorService.GetAllAuthors();

            return View(book);
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var book = bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.PublisherId = new SelectList(publisherService.GetAllPublishers(), "Id", "Name");
            return View(book);
        }


        [HttpPost]
        public ActionResult Edit([Bind("Id,Title,BookImage,Price,Rating, PublisherId")] Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Publishers = publisherService.GetAllPublishers();
                return View(book);
            }

            bookService.UpdateBook(book);

            return RedirectToAction(nameof(Index));
        }


        // GET: BookController/Delete/5
        public ActionResult Delete(Guid id)
        {
            bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
