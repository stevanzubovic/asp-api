using Application.DTOs;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetOneBook : IGetOneBookQuery
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetOneBook(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 12;

        public string Name => "Get book by id";

        public BookDTO Execute(int id)
        {
            var books = libraryContext.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                .Include(b => b.BookGenre).ThenInclude(bg => bg.Genre);

            var book = books.Where(b => b.Id == id).FirstOrDefault();

            if(book == null)
            {
                throw new EntityNotFoundException(id, typeof(Book));
            }

            var bookDTO = mapper.Map<BookDTO>(book);

            return bookDTO;

        }
    }
}
