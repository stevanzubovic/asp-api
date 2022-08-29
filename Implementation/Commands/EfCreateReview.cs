using Application;
using Application.Commands.Reviews;
using Application.DTOs.Reviews;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EfCreateReview : ICreateReviewCommand
    {
        private readonly LibraryContext libraryContext;
        private readonly ReviewValidator validator;
        private readonly IApplicationActor actor;

        public EfCreateReview(LibraryContext libraryContext, ReviewValidator validator, IApplicationActor actor)
        {
            this.libraryContext = libraryContext;
            this.validator = validator;
            this.actor = actor;
        }

        public int Id => 25;

        public string Name => "Create review";

        public void Execute(ReviewDTO dto)
        {
            var actorId = actor.Id;
            var review = new Review
            {
                UserId = actorId,
                BookId = dto.BookId,
                ReviewContent = dto.ReviewContent
            };

            validator.ValidateAndThrow(review);

            libraryContext.Reviews.Add(review);
            libraryContext.SaveChanges();

        }
    }
}
