using Application.Commands.Reviews;
using Application.DTOs.Reviews;
using Application.Exceptions;
using AutoMapper;
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
    public class EfUpdateReview : IUpdateReviewCommand
    {
        private readonly LibraryContext libraryContext;
        private readonly ReviewValidator validator;
        private readonly IMapper mapper;

        public EfUpdateReview(LibraryContext libraryContext, ReviewValidator validator, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 27;

        public string Name => "Update review";

        public void Execute(ReviewUpdateDTO dto)
        {

            var review = libraryContext.Reviews.Find(dto.Id);

            if(review == null)
            {
                throw new EntityNotFoundException(dto.Id, typeof(Review));
            }
            review.ReviewContent = dto.ReviewContent;

            validator.ValidateAndThrow(review);

            libraryContext.SaveChanges();

        }
    }
}
