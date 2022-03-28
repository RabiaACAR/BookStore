using AutoMapper;
using BookStore.Context;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorViewModel Model;
        public CreateAuthorCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.Where(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName && x.Birthday==Model.Birthday).FirstOrDefault();
            if (author is not null)
            {
                throw new InvalidOperationException("Bu özellikleri sahip yazar bulunmaktadır.");
            }
            else
            {
                 author = _mapper.Map<Author>(Model);
                _context.Authors.Add(author);
                _context.SaveChanges();
            }
        }
    }
    public class CreateAuthorViewModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
       

    }
}
