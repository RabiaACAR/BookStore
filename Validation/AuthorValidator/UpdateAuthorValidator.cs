using BookStore.Application.AuthorOperations.Command.UpdateAuthor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validation.AuthorValidator
{
    public class UpdateAuthorValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(command => command.Model.FirstName).MinimumLength(2).WithMessage("Yazar adı en az 3 karakter olmalı");
            RuleFor(command => command.Model.LastName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(command => command.Model.LastName).MinimumLength(2).WithMessage("Yazar soyadı en az 3 karakter olmalı");
            RuleFor(command => command.Model.Birthday).NotEmpty().WithMessage("Doğum bilgisi boş geçilemez");
            RuleFor(command => command.Model.Birthday).LessThan(DateTime.Now.Date);
        }
    }
}
