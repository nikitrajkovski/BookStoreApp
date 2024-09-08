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
    public class AuthorService : IAuthorService
    {

        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void CreateNewAuthor(Author author)
        {
            _authorRepository.Insert(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll().ToList();
        }

        public Author GetDetailsForAuthor(Guid? id)
        {
            return _authorRepository.Get(id);
        }
    }
}
