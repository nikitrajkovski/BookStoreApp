using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetDetailsForAuthor(Guid? id);
        void CreateNewAuthor(Author author);
    }
}
