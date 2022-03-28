using BookStore.Application.AuthorOperations.Command.DeleteAuthor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(command => command.authorId).NotEmpty().WithMessage("Yazar id boş geçilemez");
            RuleFor(command => command.authorId).GreaterThan(0).WithMessage("Yazar id 0'dan büyük olmalıdır.");
           
        }
    }
}
