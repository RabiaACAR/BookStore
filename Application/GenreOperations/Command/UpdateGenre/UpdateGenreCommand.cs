using AutoMapper;
using BookStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Command.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreContext _context;
        public int id { get; set; }
        public UpdateGenreViewModel Model { get; set; }
        public UpdateGenreCommand(BookStoreContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            if (genre is null)
            {
                throw new InvalidOperationException("Böyle bir genre yok");
            }
            if (_context.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id!=id))
            {
                throw new InvalidOperationException("Aynı isme sahip kitap türü var ");
            }

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) == default ? genre.Name : Model.Name;
            genre.isActive = Model.isActive;
            _context.SaveChanges();
        }
        public class UpdateGenreViewModel
        {
           
            public string Name { get; set; }
            public bool isActive { get; set; }
        }
    }
}
