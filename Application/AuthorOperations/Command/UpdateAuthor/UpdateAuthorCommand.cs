using BookStore.Context;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int id { get; set; }
        private readonly BookStoreContext _context;
        public UpdateAuthorCommandViewModel Model;
        public UpdateAuthorCommand(BookStoreContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");

            }
            else
            {             
                author.FirstName = Model.FirstName != default ? Model.FirstName : author.FirstName;
                author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
                author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;
                _context.SaveChanges();
            }

        }
        public class UpdateAuthorCommandViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthday { get; set; }

        }
    }
   
}
