using Application.DTOs;
using Application.Queries;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetAuthors : IGetAuthorsQuery
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetAuthors(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Get authors with search";

        public IEnumerable<AuthorDTO> Execute(string searchTerm)
        {
            var query = libraryContext.Authors.AsQueryable();

            if(!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm));
            }

            return query.Select(x => mapper.Map<AuthorDTO>(x)).ToList();
        }
    }
}
