using BookStore.BookOperations.GetById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class GetByIdValidator:AbstractValidator<BooksGetByIdCommand>
    {
        public GetByIdValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id bilgisi boş olamaz");
            RuleFor(x => x.id).GreaterThan(0).WithMessage("Id bilgisi 0'dan büyük olmalıdır");
        }
    }
}
