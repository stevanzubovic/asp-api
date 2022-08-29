using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateAuthorValidator : AbstractValidator<AuthorDTO>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Birth date is required");
            RuleFor(x => x.BirthDate)
                .Must(IsDateInFuture)
                .WithMessage("Author cannot be from the future");
                
        }

        private bool IsDateInFuture(DateTime date)
        {
            return (date < DateTime.Now);
        }
    }
}
