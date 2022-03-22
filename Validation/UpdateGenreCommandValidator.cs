using BookStore.Application.GenreOperations.Command.UpdateGenre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim()!= string.Empty);
        }
    }
}
