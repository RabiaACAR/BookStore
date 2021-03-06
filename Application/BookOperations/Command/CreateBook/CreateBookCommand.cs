using AutoMapper;
using BookStore.Context;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookViewModel Model { get; set; }
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add()
        {
            var book = _context.Books.SingleOrDefault(x=>x.Title==Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");


            //book = new Book();
            //book.Title = Model.Title;
            //book.PageCount = Model.PageCount;
            //book.PublishDate = Model.PublishDate;
            //book.GenreId = Model.GenreId;
            book = _mapper.Map<Book>(Model);//Model ile gelen objeyi book objesine convert et.
            _context.Books.Add(book);
            _context.SaveChanges(); 
                 
        }
    }

    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
