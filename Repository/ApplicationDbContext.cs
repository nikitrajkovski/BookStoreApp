using Domain.Identity;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<BookAppUser>
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<BookInShoppingCart> BookInShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<BookInOrder> BookInOrders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
