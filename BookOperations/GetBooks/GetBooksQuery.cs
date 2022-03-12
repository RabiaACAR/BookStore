using BookStore.Common;
using BookStore.Context;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreContext _context;
        public GetBooksQuery(BookStoreContext context)
        {
            _context = context;
        }

        public List<BookViewModel> Handle()
        {
            var bookList = _context.Books.ToList();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BookViewModel()
                {
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
                });}
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
