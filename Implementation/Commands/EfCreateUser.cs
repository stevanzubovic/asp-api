using Application.Commands.Users;
using Application.DTOs;
using Application.Email;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Password;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EfCreateUser : ICreateUserCommand
    {
        private readonly LibraryContext libraryContext;
        private readonly UserValidator validator;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;

        public EfCreateUser(LibraryContext libraryContext, UserValidator validator, IMapper mapper, IEmailSender emailSender)
        {
            this.libraryContext = libraryContext;
            this.validator = validator;
            this.mapper = mapper;
            this.emailSender = emailSender;
        }

        public int Id => 21;

        public string Name => "Create user";

        public void Execute(UserDTO userDto)
        {
            validator.ValidateAndThrow(userDto);

            userDto.Password = PasswordHandler.ecrypt(userDto.Password);

            var user = mapper.Map<User>(userDto);

            libraryContext.Users.Add(user);
            libraryContext.SaveChanges();

            emailSender.SendEmail(new EmailOut
            {
                Subject = "Registration - Neat Reads",
                Receiver = userDto.Email,
                Content = "<h1>Your registration was successfull<h1>"
            });


        }

     
    }
}
