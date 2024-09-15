using Domain.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPartnerBookService
    {
        List<Book> GetAllBooks();
        Book GetDetailsForBook(Guid? id);
        void CreateNewBook(Book book);
        void DeleteBook(Guid id);
        void UpdateBook(Book book);
        List<Book> getAllPublisherBooks(Guid? id);
    }
}
