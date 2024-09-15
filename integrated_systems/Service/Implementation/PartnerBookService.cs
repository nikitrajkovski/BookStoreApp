using Domain.Partner;
using Repository.Implementation;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PartnerBookService : IPartnerBookService
    {
        private readonly IPartnerRepository<Book> _bookRepository;
        private readonly IPartnerRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IPartnerRepository<Author> _authorRepository;
        private readonly IPartnerRepository<Publisher> _publisherRepository;

        public PartnerBookService(IPartnerRepository<Book> bookRepository, IPartnerRepository<BookInShoppingCart> bookInShoppingCartRepository, IPartnerRepository<Author> authorRepository, IPartnerRepository<Publisher> publisherRepository)
        {
            _bookRepository = bookRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }
        public void CreateNewBook(Book book)
        {
            _bookRepository.Insert(book);
        }

        public void DeleteBook(Guid id)
        {
            var book = _bookRepository.Get(id);
            _bookRepository.Delete(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public List<Book> getAllPublisherBooks(Guid? id)
        {
            return _bookRepository.GetAll().Where(x => x.PublisherId == id).ToList();
        }

        public Book GetDetailsForBook(Guid? id)
        {
            return _bookRepository.Get(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
