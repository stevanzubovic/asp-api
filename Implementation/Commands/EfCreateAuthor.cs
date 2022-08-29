using Application.DTOs;
using AutoMapper;
using Domain;
using EfDataAccess;
using Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Authors;

namespace Implementation.Commands
{
    public class EfCreateAuthor : ICreateAuthorCommand
    {

        private readonly IMapper mapper;
        private readonly LibraryContext context;
        private readonly CreateAuthorValidator validator;
        public EfCreateAuthor(LibraryContext context, IMapper mapper, CreateAuthorValidator validator)
        {
            this.mapper = mapper;
            this.context = context;
            this.validator = validator;
        }
        public int Id => 2;

        public string Name => "Create new author";

        public void Execute(AuthorDTO request)
        {
            var author = mapper.Map<Author>(request);

            validator.ValidateAndThrow(request);

            context.Add(author);
            context.SaveChanges();
        }
    }
}
