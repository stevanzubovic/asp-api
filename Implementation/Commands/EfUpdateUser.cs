using Application.Commands.Users;
using Application.DTOs;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Password;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EfUpdateUser : IUpdateUserCommand
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;
        private readonly UserValidator validator;

        public EfUpdateUser(LibraryContext libraryContext, IMapper mapper, UserValidator validator)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 25;

        public string Name => "Update user";

        

        public void Execute(UserDTO updatedUserDto)
        {
            validator.ValidateAndThrow(updatedUserDto);

            var user = libraryContext.Users.Find(updatedUserDto.Id);
            if (user == null)
            {
                throw new EntityNotFoundException(updatedUserDto.Id, typeof(User));
            }

            updatedUserDto.Password = PasswordHandler.ecrypt(updatedUserDto.Password);

            mapper.Map(updatedUserDto, user);

            libraryContext.SaveChanges();
        }
    }
}
