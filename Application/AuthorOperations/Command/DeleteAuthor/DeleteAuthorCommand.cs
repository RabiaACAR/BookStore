using AutoMapper;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public int authorId;
        public DeleteAuthorCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            var books = _context.Books.ToList();

            
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            else if (_context.Books.FirstOrDefault(x => x.Id == author.BookId) is not null)
            {
                throw new InvalidOperationException("Kitabı olan yazar silinemez");
            }
            else
            {
                _context.Remove(author);
                _context.SaveChanges();
            }
            
            
        }
       
    }
    
}
