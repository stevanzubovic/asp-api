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
    public class EfGetOneUser : IGetOneUserQuery
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public EfGetOneUser(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public int Id => 24;

        public string Name => "Get user by id";

        public UserDTO Execute(int id)
        {
            var user = libraryContext.Users.Find(id);

            if( user == null )
            {
                throw new EntityNotFoundException(id, typeof(User));
            }
            return mapper.Map<UserDTO>(user);

        }
    }
}
