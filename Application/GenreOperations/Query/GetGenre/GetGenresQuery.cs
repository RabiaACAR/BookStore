using AutoMapper;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Query.GetGenre
{
    public class GetGenresQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.isActive == true).ToList().OrderBy(x => x.Id);
            var result = _mapper.Map<List<GenresViewModel>>(genres);
            return result;
        }
    }
        public class GenresViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        public bool isActive { get; set; }
    }
    }

