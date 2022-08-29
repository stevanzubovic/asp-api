using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<UserUseCase> UseCases { get; set; } = new List<UserUseCase>();
    }
}
