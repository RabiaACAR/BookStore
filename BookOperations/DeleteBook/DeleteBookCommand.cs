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

        public DeleteBookCommand(BookStoreContext context)
        {
            _context = context;
        }
        public void Handle(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap yok");
            }
            else
            {
                DeleteBookViewModel model = new DeleteBookViewModel();
                model.Id = book.Id;
                model.Genre = ((GenreEnum)book.GenreId).ToString();
                model.Title = book.Title;
                model.PageCount = book.PageCount;
                model.PublishDate = book.PublishDate;
                _context.Remove(book);
                _context.SaveChanges();

            }
        }


    }

    public class DeleteBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
