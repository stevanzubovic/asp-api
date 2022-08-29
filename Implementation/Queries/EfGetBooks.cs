using Application.DTOs;
using Application.Queries;
using AutoMapper;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetBooks : IGetBooksQuery
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetBooks(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Search books";

        public IEnumerable<BookDTO> Execute(BookSearchDTO search)
        {
            var books = libraryContext.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                 .Include(b => b.BookGenre).ThenInclude(bg => bg.Genre).AsQueryable();

            if (!string.IsNullOrEmpty(search.Author))
            {
                books = books.Where(b => b.Title.Contains(search.Title));
            }
            if (!string.IsNullOrEmpty(search.Genre))
            {
                books = books.Where(b => b.BookGenre.Any(bg => bg.Genre.Name.Contains(search.Genre)));
            }
            if (!string.IsNullOrEmpty(search.Author))
            {
                books = books.Where(b => b.BookAuthors.Any(ba => ba.Author.LastName.Contains(search.Author) 
                || ba.Author.FirstName.Contains(search.Author)));
            }
            if(!string.IsNullOrEmpty(search.Description))
            {
                books = books.Where(b => b.Description.Contains(search.Description));
            }
            if(!string.IsNullOrEmpty(search.Language))
            {
                books = books.Where(b => b.Language.Contains(search.Language));
            }

            var response = books.Select(b => mapper.Map<BookDTO>(b)).ToList();

            return response;

        }
    }
}
