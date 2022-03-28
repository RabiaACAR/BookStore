using BookStore.Application.AuthorOperations.Command.CreateAuthor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorViewModel>
    {
        public CreateAuthorValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(command => command.FirstName).MinimumLength(2).WithMessage("Yazar adı en az 3 karakter olmalı");
            RuleFor(command => command.LastName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(command => command.LastName).MinimumLength(2).WithMessage("Yazar soyadı en az 3 karakter olmalı");
            RuleFor(command => command.Birthday).NotEmpty().WithMessage("Doğum bilgisi boş geçilemez");
            RuleFor(command => command.Birthday).LessThan(DateTime.Now.Date);

        }
    }
}
