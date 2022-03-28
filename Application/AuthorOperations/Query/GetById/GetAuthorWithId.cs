using AutoMapper;
using BookStore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Query.GetById
{
    public class GetAuthorWithId
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public int authorsId;
        public GetAuthorWithId(BookStoreContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public GetByIdAuthorViewModel Handle()
        {
            var author = _context.Authors/*.Include(x=>x.Book)*/.FirstOrDefault(x => x.Id == authorsId);
            if (author is null)
            {
                throw new InvalidOperationException("Böyle bir yazar bulunamadı");
            }
            var result = _mapper.Map<GetByIdAuthorViewModel>(author);
            return result;
        }
        public class GetByIdAuthorViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthday { get; set; }            
            public string BookName { get; set; }
        }
        

    }
}
