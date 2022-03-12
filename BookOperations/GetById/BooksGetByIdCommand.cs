using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.GetById
{
    public class BooksGetByIdCommand
    {
        private readonly BookStoreContext _context;
        public int id { get; set; }

        public BooksGetByIdCommand(BookStoreContext context)
        {
            _context = context;
        }
        public GetByIdViewModel Handle()
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            return new GetByIdViewModel()
            {
                GenreId = book.GenreId,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate,
                Title = book.Title
            };

        }

        public class GetByIdViewModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
