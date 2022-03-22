using AutoMapper;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Command.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId;
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public DeleteGenreCommand(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public DeleteGenreViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id==GenreId );
            if (genre is null)
            {
                throw new InvalidOperationException("Kitao türü bulunamadı");
            }
            else
            {
                genre.isActive = false;
                _context.SaveChanges();
                return _mapper.Map<DeleteGenreViewModel>(genre);
            }
        }
        public class DeleteGenreViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
