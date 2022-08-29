using Application.Commands.Books;
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
    public class EfDeleteBook : IDeleteBookCommand
    {
        private readonly LibraryContext libraryContext;

        public EfDeleteBook(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 14;

        public string Name => "Delete book";

        public void Execute(int id)
        {
            var book = libraryContext.Books.Find(id);

            if(book == null)
            {
                throw new EntityNotFoundException(id, typeof(Book));
            }

            book.IsDeleted = true;

            libraryContext.SaveChanges();
        }
    }
}
