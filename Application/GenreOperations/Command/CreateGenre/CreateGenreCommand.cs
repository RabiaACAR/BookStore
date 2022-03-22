using AutoMapper;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Command.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set; }
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.Where(x => x.Name == Model.Name).SingleOrDefault();
            if (genre is not null)
            {
                throw new InvalidOperationException("Kitap türü zaten mevcut");
            }
            genre = new Entity.Genre();
            genre.Name = Model.Name;
            _context.Add(genre);
            _context.SaveChanges();

        }
    
    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}
}