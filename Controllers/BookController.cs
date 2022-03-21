using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetById;
using BookStore.BookOperations.UpdateBook;
using BookStore.Context;
using BookStore.Entity;
using BookStore.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreContext _context;
        public BookController(BookStoreContext context)
        {
            _context = context;
        }


        //public static List<Book> BookList = new List<Book>()
        //{
        //   new Book{ Id=1, Title="Lean Startup", GenreId=1, PageCount=200, PublishDate=new DateTime(2001, 06,12)},
        //   new Book{Id=2, Title="Kırlangıç Çığlığı", GenreId=2, PageCount=300, PublishDate=new DateTime(1999, 06,23)},
        //   new Book{Id=3, Title="1984", GenreId=3, PageCount=400, PublishDate=new DateTime(2020,03,04)},
        //   new Book{Id=4, Title="İstanbul Beyefendisi", GenreId=1, PageCount=500, PublishDate=new DateTime(2014,4,23)},
        //   new Book{Id=5, Title="Kuyucaklı Yusuf", GenreId=2, PageCount=250, PublishDate=new DateTime(2018, 4, 12)}
        //};

        //[HttpGet]//Bu olmadan çalışmaz
        ////id query stringden alınıyor
        //public List<Book> GetBooks()
        //{
        //    return BookList.OrderBy(x => x.Id).ToList();
        //}

        //[HttpGet("{id}")]
        //public Book GetById(int id)
        //{
        //    return BookList.Where(x => x.Id == id).FirstOrDefault();
        //}



        //FromQuery yöntemi ile belirtilen id'ye ait bookun getirilmesi
        //[HttpGet]
        //public IActionResult GetById([FromQuery]int id)
        //{
        //    //var book = BookList.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
        //    //if (book is null)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    //else
        //    //{
        //    //    return Ok();
        //    //}




        //}


        //Ekleme yapılıcak
        //[HttpPost]
        //public IActionResult AddBook([FromBody] Book book)
        //{
        //    var newBook = BookList.SingleOrDefault(X => X.Title == book.Title);
        //    if (newBook is not null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        BookList.Add(book);
        //        return Ok();
        //    }

        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateBook(int id, [FromBody] Book updatedbook)
        //{
        //    var book = BookList.SingleOrDefault(x => x.Id == id);
        //    if (book is null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        book.GenreId = updatedbook.GenreId != default ? updatedbook.GenreId : book.GenreId;
        //        book.PageCount = updatedbook.PageCount != default ? updatedbook.PageCount : book.PageCount;
        //        book.PublishDate = updatedbook.PublishDate != default ? updatedbook.PublishDate : book.PublishDate;
        //        book.Title = updatedbook.Title != default ? updatedbook.Title : book.Title;

        //        return Ok();
        //    }
        //}
        //[HttpDelete("{id}")]
        //public IActionResult DeleteBook(int id)
        //{
        //    var book = BookList.SingleOrDefault(x => x.Id == id);
        //    if (book is null)
        //    {
        //        return BadRequest();

        //    }
        //    else
        //    {
        //        BookList.Remove(book);
        //        return Ok();
        //    }

        //}


        //ENTITY FRAMEWORK CORE ILE
        //[HttpGet]
        //public List<Book> GetBooks()
        //{
        //    return _context.Set<Book>().OrderBy(x=>x.Id).ToList();
        //}

        //[HttpGet]
        //public Book GetById(int id)
        //{
        //    var book = _context.Books.Where(x=>x.Id==id).SingleOrDefault();
        //    if (book is null)
        //    {
        //        return null;
        //    }
        //    return _context.Set<Book>().Find(id);
        //}

        //[HttpPost]
        //public IActionResult AddBook(Book book)
        //{
        //    var oldbook = _context.Books.SingleOrDefault();
        //    if (oldbook is null)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Set<Book>().Add(book);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public IActionResult updateBook(int id, [FromBody] Book updatedbook)
        //{
        //    var book = _context.Books.SingleOrDefault(x => x.Id == id);
        //    if (book is null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        book.GenreId = updatedbook.GenreId != default ? updatedbook.GenreId : book.GenreId;
        //        book.PageCount = updatedbook.PageCount != default ? updatedbook.PageCount : book.PageCount;
        //        book.PublishDate = updatedbook.PublishDate != default ? updatedbook.PublishDate : book.PublishDate;
        //        book.Title = updatedbook.Title != default ? updatedbook.Title : book.Title;
        //        _context.SaveChanges();
        //        return Ok();

        //    }
        //}
        //[HttpDelete("{id}")]
        //public IActionResult deleteBook(int id)
        //{
        //    var book = _context.Set<Book>().Find(id);
        //    if (book is null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        _context.Remove(book);
        //        _context.SaveChanges();
        //        return Ok(); 
        //    }
        //}

        //VIEWMODEL KULLANARAK CRUD
         [HttpGet]
         public IActionResult getBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]

        public IActionResult AddBook([FromBody]CreateBookViewModel AdddedBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
         
                command.Model = AdddedBook;
                CreateBookValidator validationRules = new CreateBookValidator();
                validationRules.ValidateAndThrow(AdddedBook);
                command.Add();
          
            return Ok(AdddedBook);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooksGetByIdCommand command = new BooksGetByIdCommand(_context);
          
                command.id = id;
                GetByIdValidator validationRules = new GetByIdValidator();
                validationRules.ValidateAndThrow(command);
                command.Handle();
           
            return Ok(command.Handle());
        }
        [HttpPut/*("{id}")*/]
        public IActionResult updateBook(/*int id,*/ [FromBody] UpdateBookViewModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
           
                //command.id = id;
                command.Model = updatedBook;
                UpdateBookValidator validationRules = new UpdateBookValidator();
                validationRules.ValidateAndThrow(updatedBook);
                command.Handle();
           
            return Ok(updatedBook);
        }
        [HttpDelete("{id}")]
        public IActionResult deletedBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            
          
                command.id = id;
                DeleteBookValidator validationRules = new DeleteBookValidator();
                validationRules.ValidateAndThrow(command);
                command.Handle();
            
            return Ok();
        }




        
    }
}
