using Application.DTOs;
using Domain;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator(LibraryContext libraryContext)
        {
            RuleFor(x => x.ReviewContent).NotEmpty()
                .WithMessage("Review cannot be empty");
            RuleFor(x => x.BookId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Invalid book id")
                .Must(id => libraryContext.Books.Any(b => b.Id == id))
                .WithMessage("No book with given id");

        }
    }
}
