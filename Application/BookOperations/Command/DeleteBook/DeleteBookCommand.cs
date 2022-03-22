using BookStore.Common;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
       
        private readonly BookStoreContext _context;
        public int id { get; set; }

        public DeleteBookCommand(BookStoreContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap yok");
            }
            else
            {
             
                _context.Remove(book);
                _context.SaveChanges();

            }
        }


    }
   


}
