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
    public class EfGetUsers : IGetUsersQuery
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetUsers(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 23;

        public string Name => "Search users";

        public IEnumerable<UserDTO> Execute(UserSearchDTO searchTerms)
        {
            var query = libraryContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerms.Username) || !string.IsNullOrWhiteSpace(searchTerms.Username))
            {
                query = query.Where(u => u.UserName.Contains(searchTerms.Username));
            }
            if (!string.IsNullOrEmpty(searchTerms.FirstName) || !string.IsNullOrWhiteSpace(searchTerms.FirstName))
            {
                query = query.Where(u => u.FirstName.Contains(searchTerms.FirstName));
            }
            if (!string.IsNullOrEmpty(searchTerms.LastName) || !string.IsNullOrWhiteSpace(searchTerms.LastName))
            {
                query = query.Where(u => u.LastName.Contains(searchTerms.LastName));
            }
            if (!string.IsNullOrEmpty(searchTerms.Email) || !string.IsNullOrWhiteSpace(searchTerms.Email))
            {
                query = query.Where(u => u.Email.Contains(searchTerms.Email));
            }

            var response = query.Select(u => mapper.Map<UserDTO>(u)).ToList();

            return response;
        }
    }
}
