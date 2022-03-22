using AutoMapper;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Query.GetByIdr
{
    public class GetByIdGenre
    {
        public int genreId { get; set; }
        public BookStoreContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public GetByIdGenre(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == genreId && x.isActive==true) ;
            if (genre is null)
            {
                throw new InvalidOperationException("Bu bir genre yok");
            }
            GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);

            return vm;
        }
 }
        public class GenreDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
       
    }
}
