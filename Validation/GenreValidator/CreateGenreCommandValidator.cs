using BookStore.Application.GenreOperations.Command.CreateGenre;
using BookStore.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
