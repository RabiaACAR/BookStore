using BookStore.BookOperations.DeleteBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class DeleteBookValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id bilgisi boş geçilemez");
            //RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır."); 
        }
    }
}
