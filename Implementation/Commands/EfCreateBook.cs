using Application.Commands.Books;
using Application.DTOs;
using AutoMapper;
using Domain;
using EfDataAccess;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EfCreateBook : ICreateBookCommand
    {
        private readonly IMapper mapper;
        private readonly LibraryContext context;
        private readonly CreateBookValidator validator;
        public EfCreateBook(LibraryContext context, IMapper mapper, CreateBookValidator validator)
        {
            this.mapper = mapper;
            this.context = context;
            this.validator = validator;
        }
        public int Id => 1;

        public string Name => "Create book";

        public void Execute(BookDTO request)
        {
            var book = mapper.Map<Book>(request);

            validator.Validate(request);

            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}
