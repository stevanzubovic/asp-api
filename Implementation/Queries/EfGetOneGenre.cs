using Application.DTOs;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetOneGenre : IGetOneGenreQuery
    {

        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetOneGenre(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Get genre by id";

        public GenreDTO Execute(int id)
        {
            var genre = libraryContext.Genres.Find(id);

            if (genre == null)
            {
                throw new EntityNotFoundException(id, typeof(Genre));
            }

            var response = mapper.Map<GenreDTO>(genre);

            return response;
        }
    }
}
