using Application.Features.Book.Command.CreateBook;
using Application.Features.Book.Command.DeleteBook;
using Application.Features.Book.Command.UpdateBook;
using Application.Features.Book.Queries.GetAllBooks;
using Application.Features.Book.Queries.GetBook;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookDetailsDto, Book>().ReverseMap();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<DeleteBookCommand, Book>();
        }
    }
}
