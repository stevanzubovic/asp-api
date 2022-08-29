using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using EfDataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator(LibraryContext libraryContext)
        {
            RuleFor(x => x.Username)
                .Must(username => !libraryContext.Users.Any(u => u.UserName == username))
                .WithMessage("Username already exists")
                .NotEmpty()
                .WithMessage("Username is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Valid Email adress is required");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Minimum password length is 8 characters");
        }
    }
}
