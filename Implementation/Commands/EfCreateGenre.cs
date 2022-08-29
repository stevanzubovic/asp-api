using Application.Commands.Genres;
using Application.DTOs;
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
    public class EfCreateGenre : ICreateGenreCommand
    {
        private readonly IMapper mapper;
        private readonly LibraryContext context;
        private readonly GenreValidator validator;

        public EfCreateGenre(IMapper mapper, LibraryContext context, GenreValidator validator)
        {
            this.mapper = mapper;
            this.context = context;
            this.validator = validator;
        }

        public int Id => 3;

        public string Name => "Create genre";

        public void Execute(GenreDTO request)
        {
            var genre = mapper.Map<Genre>(request);

            validator.ValidateAndThrow(request);

            context.Add(genre);
            context.SaveChanges();
        }
    }
}
