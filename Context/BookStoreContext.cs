using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Context
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) :base(options)
        {

        }
        public DbSet<Book> Books { get; set;}
        public DbSet<Genre> Genres { get; set; }
    }
}
