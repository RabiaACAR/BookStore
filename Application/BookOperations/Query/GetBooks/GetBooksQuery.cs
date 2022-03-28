using AutoMapper;
using BookStore.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
            var bookList = _context.Books.Include(x=>x.Genre).ToList();
            //List<BookViewModel> vm = new List<BookViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BookViewModel()
            //    {
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        Title = book.Title,
            //        PageCount = book.PageCount,
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
            //    });}
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(bookList);
            return vm;
        }          
            
        
    }
    public class BookViewModel
    {       
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
