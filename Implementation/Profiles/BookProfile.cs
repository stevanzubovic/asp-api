using Application.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, Book>()
                .ForMember(dto => dto.BookAuthors, opt => opt.MapFrom(dto => dto.BookAuthors.Select(x => new BookAuthor
                {
                    AuthorId = x.AuthorId,
                    BookId = x.BookId,
                })))
                .ForMember(dest => dest.BookGenre, opt => opt.MapFrom(dest => dest.BookGenres.Select(x => new BookGenre
                {
                    GenreId = x.GenreId,
                    BookId = x.BookId
                })));

            CreateMap<Book, BookDTO>()
                .ForMember(b => b.BookGenres, opt => opt.MapFrom(b => b.BookGenre.Select(bg => new BookGenreDTO
                {
                    Genre = bg.Genre.Name
                })))
                .ForMember(b => b.BookAuthors, opt => opt.MapFrom(b => b.BookAuthors.Select(ba => new BookAuthorDTO
                {
                    AuthorId = ba.AuthorId,
                    Name = ba.Author.FirstName + " " + ba.Author.LastName
                })));
        }
    }
}
