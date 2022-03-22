using BookStore.Application.GenreOperations.Query.GetByIdr;
using BookStore.Application.GenreOperations.Query.GetGenre;
using BookStore.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.Application.GenreOperations.Query.GetGenre.GetGenresQuery;

namespace BookStore.Validation
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetByIdGenre>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.genreId).GreaterThan(0).WithMessage("GenreId 0'dan büyük olmalıdır.");
        }
    }
}
