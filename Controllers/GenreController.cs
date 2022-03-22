using AutoMapper;
using BookStore.Application.GenreOperations.Command.CreateGenre;
using BookStore.Application.GenreOperations.Command.DeleteGenre;
using BookStore.Application.GenreOperations.Command.UpdateGenre;
using BookStore.Application.GenreOperations.Query.GetByIdr;
using BookStore.Application.GenreOperations.Query.GetGenre;
using BookStore.Context;
using BookStore.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.Application.GenreOperations.Command.CreateGenre.CreateGenreCommand;
using static BookStore.Application.GenreOperations.Command.UpdateGenre.UpdateGenreCommand;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
            
        }
        [HttpGet("{id}")]
        public ActionResult GetGenresDetails(int id)
        {
            GetByIdGenre query = new GetByIdGenre(_context, _mapper);
            query.genreId = id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
           
            var result = query.Handle();
            return Ok(result);

        }
        [HttpPost]

        public IActionResult CreateGenre([FromBody] CreateGenreViewModel AddedGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = AddedGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(AddedGenre);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreViewModel UpdatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.id = id;
            command.Model = UpdatedGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(UpdatedGenre);

        }
        [HttpDelete("{id}")]
        public IActionResult DeletedGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context, _mapper);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
