using Application.Commands.Authors;
using Application.DTOs;
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
    public class EfDeleteAuthor : IDeleteAuthorCommand
    {
        private readonly LibraryContext libraryContext;

        public EfDeleteAuthor(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 10;

        public string Name => "Delete author";

        public void Execute(int id)
        {
            var author = libraryContext.Authors.Find(id);

            if (author == null)
            {
                throw new EntityNotFoundException(id, typeof(Author));
            }

            author.IsDeleted = true;
            libraryContext.SaveChanges();
        }
    }
}
