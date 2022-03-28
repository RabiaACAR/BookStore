using BookStore.Application.AuthorOperations.Query.GetById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class GeyByIdAuthorValidator:AbstractValidator<GetAuthorWithId>
    {
        public GeyByIdAuthorValidator()
        {
            RuleFor(x => x.authorsId).NotEmpty().WithMessage("Id bilgisi boş olamaz");
            RuleFor(x => x.authorsId).GreaterThan(0).WithMessage("Id bilgisi 0'dan büyük olmalıdır");
        }
    }
}
