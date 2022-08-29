using Application.Commands.Users;
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
    public class EfDeleteUser : IDeleteUserCommand
    {
        private readonly LibraryContext libraryContext;

        public EfDeleteUser(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public int Id => 22;

        public string Name => "Delete user";

        public void Execute(int id)
        {
            var user = libraryContext.Users.Find(id);

            if(user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            user.IsDeleted = true;
            libraryContext.SaveChanges();
        }
    }
}
