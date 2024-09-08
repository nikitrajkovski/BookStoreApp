using BookStore.Data;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<BookAppUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BookAppUser>();
        }

        public IEnumerable<BookAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Delete(BookAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public BookAppUser Get(string? id)
        {
            return entities
                .Include(z => z.ShoppingCart)
                .Include("ShoppingCart.BookInShoppingCarts")
                .Include("ShoppingCart.BookInShoppingCarts.Book")
                .SingleOrDefault(z => z.Id == id);
        }

        public void Insert(BookAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
