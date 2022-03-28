using AutoMapper;
using BookStore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Query.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAuthorsViewModel> Handle()
        {
            var authors = _context.Authors.ToList();
            List <GetAuthorsViewModel> result= _mapper.Map<List<GetAuthorsViewModel>>(authors);
            return result;
        }

        public class GetAuthorsViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthday { get; set; }
            public string bookName { get; set; }
        }
    }
}
