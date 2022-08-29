using Application.DTOs;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class GenreValidator : AbstractValidator<GenreDTO>
    {
        public GenreValidator(LibraryContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Genre name is required")
                .Must(name => !context.Genres.Any(g => g.Name == name))
                .WithMessage("Genre with that name already exists");
                
        }
    }
}
