using Application.Commands.Authors;
using Application.DTOs;
using Application.Exceptions;
using AutoMapper;
using Domain;
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
    public class EfUpdateAuthor : IUpdateAuthorCommand
    {

        private readonly LibraryContext libraryContext;
        private readonly CreateAuthorValidator validator;
        private readonly IMapper mapper;

        public EfUpdateAuthor(LibraryContext libraryContext, CreateAuthorValidator validator, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Update author";

        public void Execute(AuthorDTO request)
        {
            var author = libraryContext.Authors.Find(request.Id);
            if (author == null)
            {
                throw new EntityNotFoundException(Id, typeof(Author));
            }

            mapper.Map(request, author);

            validator.ValidateAndThrow(request);

            libraryContext.SaveChanges();

        }
    }
}
