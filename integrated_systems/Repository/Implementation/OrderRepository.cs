using BookStore.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private DbSet<Order> entities;
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            this._context = context;
            entities = context.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            return entities
               .Include(z => z.BooksInOrder)
               .Include(z => z.Owner)  
               .Include("BooksInOrder.Book")
               .ToList();
        }
        public Order GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include(z => z.BooksInOrder)
                .Include(z => z.Owner)
                .Include("BooksInOrder.Book")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
