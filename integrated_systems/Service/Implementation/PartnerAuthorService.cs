using Domain.Partner;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PartnerAuthorService : IPartnerAuthorService
    {
        private readonly IPartnerRepository<Author> _authorRepository;

        public PartnerAuthorService(IPartnerRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void CreateNewAuthor(Author author)
        {
            _authorRepository.Insert(author);
        }

        public void DeleteAuthor(Guid id)
        {
            var author = _authorRepository.Get(id);
            _authorRepository.Delete(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll().ToList();
        }

        public Author GetDetailsForAuthor(Guid? id)
        {
            return _authorRepository.Get(id);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
