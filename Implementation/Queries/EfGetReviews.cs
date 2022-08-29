using Application.DTOs.Reviews;
using Application.Queries;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class EfGetReviews : IGetReviewsQuery
    {
        private readonly LibraryContext libraryContext;

        public EfGetReviews(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 29;

        public string Name => "Search reviews";

        public IEnumerable<ReviewOutputDTO> Execute(ReviewSearchDTO searchParams) { 
            var query = libraryContext.Reviews.Include(r => r.User).Include(r => r.Book).AsQueryable();

            if(!string.IsNullOrEmpty(searchParams.Username) && !string.IsNullOrWhiteSpace(searchParams.Username))
            {
                query = query.Where(x => x.User.UserName.Contains(searchParams.Username));
            }
            if (!string.IsNullOrEmpty(searchParams.BookTitle) && !string.IsNullOrWhiteSpace(searchParams.BookTitle))
            {
                query = query.Where(x => x.Book.Title.Contains(searchParams.BookTitle));

            }
            if (!string.IsNullOrEmpty(searchParams.ReviewContent) && !string.IsNullOrWhiteSpace(searchParams.ReviewContent))
            {
                query = query.Where(x => x.ReviewContent.Contains(searchParams.ReviewContent));
            }

            var response = query.Select(x => new ReviewOutputDTO
            {
                ReviewContent = x.ReviewContent,
                Book = x.Book.Title,
                UserName = x.User.UserName,
                CreatedAt = x.CreatedAt.ToShortDateString()
            }).ToList();

            return response;
        }
    }
}
