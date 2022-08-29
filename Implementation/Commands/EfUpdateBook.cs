using Application.Commands.Books;
using Application.DTOs;
using AutoMapper;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EfUpdateBook : IUpdateBookCommand
    {
        private readonly LibraryContext libraryContext;
        private readonly CreateBookValidator validator;
        private readonly IMapper mapper;

        public EfUpdateBook(LibraryContext libraryContext, CreateBookValidator validator, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Update book";

        public void Execute(BookDTO newBook)
        {
            validator.ValidateAndThrow(newBook);

            var book = libraryContext.Books.Find(newBook.Id);

            mapper.Map(newBook, book);

            libraryContext.SaveChanges();
    
        }
    }
}
