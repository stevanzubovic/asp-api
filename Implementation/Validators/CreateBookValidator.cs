using Application.DTOs;
using FluentValidation;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateBookValidator : AbstractValidator<BookDTO>
    {
        public CreateBookValidator(LibraryContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Title)
                .Must(title => !context.Books.Any(b => b.Title == title))
                .WithMessage("Book with that title already exists"); //different edditions?

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");
            RuleFor(x => x.BookAuthors)
                .NotEmpty()
                .WithMessage("Book must have an author");
            RuleFor(x => x.BookGenres)
                .NotEmpty()
                .WithMessage("Genre is required");
                
        }
    }
}
