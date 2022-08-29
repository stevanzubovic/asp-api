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
    public class EfGetOneAuthor : IGetOneAuthorQuery
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetOneAuthor(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Get author by id";

        public AuthorDTO Execute(int id)
        {
            var author = libraryContext.Authors.Find(id);

            if (author == null)
            {
                throw new EntityNotFoundException(id, typeof(Author));
            }

            var response = mapper.Map<AuthorDTO>(author);

            return response;
        }
    }
}
