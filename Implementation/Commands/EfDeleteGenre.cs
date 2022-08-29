using Application.Commands.Genres;
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
    public class EfDeleteGenre : IDeleteGenreCommand
    {

        private readonly LibraryContext context;

        public EfDeleteGenre(LibraryContext context)
        {
            this.context = context;
        }

        public int Id => 4;

        public string Name => "Delete genre";

        public void Execute(int id)
        {
            var genre = context.Genres.Find(id);

            if(genre == null)
            {
                throw new EntityNotFoundException(id, typeof(Genre));
            }

            genre.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
