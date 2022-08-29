using Application.DTOs;
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
    public class EfGetGenres : IGetGenresQuery
    {

        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetGenres(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Get genres";

        public IEnumerable<GenreDTO> Execute(string searchTerm)
        {
            var query = libraryContext.Genres.AsQueryable();
            
            if(!string.IsNullOrEmpty(searchTerm))
            {
               query = query.Where(x => x.Name.Contains(searchTerm));
            } else
            {
                
            }

           return query.Select(x => mapper.Map<GenreDTO>(x));
           

           // throw new NotImplementedException();
        }
    }
}
