using AutoMapper;
using BookStore.Context;
using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.GetById
{
    public class BooksGetByIdCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }

        public BooksGetByIdCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetByIdViewModel Handle()
        {
            var book = _context.Books.Include(x=>x.Genre).Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            GetByIdViewModel vm = _mapper.Map<GetByIdViewModel>(book);

            return vm;

        }

        public class GetByIdViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
