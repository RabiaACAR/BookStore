using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int id{ get; set; }
        public UpdateBookViewModel Model { get; set; }
        private readonly BookStoreContext _context;

        public UpdateBookCommand(BookStoreContext context)
        {
            _context = context;
           
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id==id);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap yok");
            }
            else
            {
                book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
                book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
                book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
                book.Title = Model.Title != default ? Model.Title : book.Title;
                _context.SaveChanges();

            }
        }
        public class UpdateBookViewModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
