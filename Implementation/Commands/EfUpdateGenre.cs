using Application.Commands.Genres;
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
    public class EfUpdateGenre : IUpdateGenreCommand
    {
        private readonly LibraryContext libraryContext;
        private readonly GenreValidator validator;
        private readonly IMapper mapper;

        public EfUpdateGenre(LibraryContext libraryContext, GenreValidator validator, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Update genre";

        public void Execute(GenreDTO request)
        {

            var genre = libraryContext.Genres.Find(request.Id);

            if (genre == null)
            {
                throw new EntityNotFoundException(Id, typeof(Genre));
            }

            validator.ValidateAndThrow(request);
   
            genre.Name = request.Name;

            libraryContext.SaveChanges();   
            
        }
    }
}
