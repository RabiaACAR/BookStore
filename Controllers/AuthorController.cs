using AutoMapper;
using BookStore.Application.AuthorOperations.Command.CreateAuthor;
using BookStore.Application.AuthorOperations.Command.DeleteAuthor;
using BookStore.Application.AuthorOperations.Command.UpdateAuthor;
using BookStore.Application.AuthorOperations.Query.GetAuthors;
using BookStore.Application.AuthorOperations.Query.GetById;
using BookStore.Context;
using BookStore.Validation;
using BookStore.Validation.AuthorValidator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.Application.AuthorOperations.Command.UpdateAuthor.UpdateAuthorCommand;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetAuthorWithId query = new GetAuthorWithId(_context, _mapper);
            query.authorsId = id;
            GeyByIdAuthorValidator validator = new GeyByIdAuthorValidator();
            validator.ValidateAndThrow(query);
            return Ok(query.Handle());
        }

        [HttpDelete("{id}")]
        public IActionResult deleteAthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context, _mapper);
            command.authorId = id;
            DeleteAuthorValidator valiator = new DeleteAuthorValidator();
            valiator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult addAuthor([FromBody] CreateAuthorViewModel addedAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = addedAuthor;
            CreateAuthorValidator validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(addedAuthor);
            command.Handle();
            return Ok(addedAuthor);
        }

        [HttpPut("{id}")]
        public IActionResult updateAuthor(int id,[FromBody] UpdateAuthorCommandViewModel updateAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.id = id;
            command.Model = updateAuthor;
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
