using Application.Commands.Reviews;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class EfDeleteReview : IDeleteReviewCommand
    {
        private readonly LibraryContext libraryContext;

        public EfDeleteReview(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 26;

        public string Name => "Delete review";

        public void Execute(int id)
        {
            var review = libraryContext.Reviews.Find(id);
            if(review == null)
            {
                throw new EntityNotFoundException(id, typeof(Review));
            }

            review.IsDeleted = true;

            libraryContext.SaveChanges();

        }
    }
}
