using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new BookStoreContext(serviceProvider.GetRequiredService < DbContextOptions<BookStoreContext>>()))
            {
                if (context.Books.Any() && context.Genres.Any())
                {
                    return;
                }
                context.Books.AddRange(
                   new Book {/* Id = 1,*/ Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
                   new Book {/* Id = 2, */Title = "Kırlangıç Çığlığı", GenreId = 2, PageCount = 300, PublishDate = new DateTime(1999, 06, 23) },
                   new Book {/* Id = 3,*/ Title = "1984", GenreId = 3, PageCount = 400, PublishDate = new DateTime(2020, 03, 04) },
                   new Book {/* Id = 4,*/ Title = "İstanbul Beyefendisi", GenreId = 1, PageCount = 500, PublishDate = new DateTime(2014, 4, 23) },
                   new Book {/* Id = 5,*/ Title = "Kuyucaklı Yusuf", GenreId = 2, PageCount = 250, PublishDate = new DateTime(2018, 4, 12) }

                );
                
                context.Genres.AddRange(
                  new Genre { Name = "PersonelGrowth" },
                  new Genre { Name = "Science Fiction" },
                  new Genre {  Name = "Romance" }


                );
                context.Authors.AddRange(
                    new Author { FirstName = "George", LastName = "Orwell", Birthday = new DateTime(1934, 4, 4), BookId = 3 },
                    new Author { FirstName = "Ahmet", LastName = "Ümit", Birthday = new DateTime(1034, 5, 5), BookId = 2 }
                    );
                context.SaveChanges();
            }
        }    
	       
    }
}
