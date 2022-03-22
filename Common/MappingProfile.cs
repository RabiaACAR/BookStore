using AutoMapper;
using BookStore.Application.GenreOperations.Query.GetByIdr;
using BookStore.Application.GenreOperations.Query.GetGenre;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBooks;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.Application.GenreOperations.Command.DeleteGenre.DeleteGenreCommand;
using static BookStore.Application.GenreOperations.Query.GetByIdr.GetByIdGenre;
using static BookStore.Application.GenreOperations.Query.GetGenre.GetGenresQuery;
using static BookStore.BookOperations.GetById.BooksGetByIdCommand;

namespace BookStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            //CreateMap<Book, GetByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //Bunun yerine
            CreateMap<Book, GetByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            //CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //Bunun yerine
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Genre, DeleteGenreViewModel>();
            CreateMap<Genre, GenresViewModel>();
        }
    }
}
