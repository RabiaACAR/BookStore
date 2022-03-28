using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Validation
{
    public class UpdateBookValidator:AbstractValidator<UpdateBookViewModel>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("GenreId 0'dan büyük olmalıdır.");
            RuleFor(x => x.PageCount).GreaterThan(0).WithMessage("Sayfa sayısı 0'dan büyük olmalıdır.");
            RuleFor(x => x.PublishDate.Date).NotEmpty().WithMessage("Tarih bilgisi boş geçilemez.");
            RuleFor(x => x.PublishDate.Date).LessThan(DateTime.Now.Date).WithMessage("Tarih bilgisi doğru değil");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık bilgisi boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(4).WithMessage("Başlık bilgisi en az 4 karakter olmalıdır."); 
        }
    }
}
