using Application.DTOs.Reviews;
using Application.Exceptions;
using Application.Queries;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetOneReview : IGetOneReviewQuery
    {

        private readonly LibraryContext libraryContext;

        public EfGetOneReview(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 28;

        public string Name => "Get review with id";

        public ReviewOutputDTO Execute(int id)
        {
            var query = libraryContext.Reviews.Include(r => r.User).Include(r => r.Book).AsQueryable();


            var response = query.Where(x => x.Id == id).Select(x => new ReviewOutputDTO
            {
                ReviewContent = x.ReviewContent,
                UserName = x.User.UserName,
                Book = x.Book.Title,
                CreatedAt = x.CreatedAt.ToShortDateString(),
            }).FirstOrDefault();

            if (response == null)
            {
                throw new EntityNotFoundException(id, typeof(Review));
            }
            return response;
        }
    }
}
