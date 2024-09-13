using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<BookAppUser> GetAll();
        BookAppUser Get(string? id);
        void Insert(BookAppUser entity);
        void Update(BookAppUser entity);
        void Delete(BookAppUser entity);
    }
}
