using BookStore.Application.GenreOperations.Command.DeleteGenre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
